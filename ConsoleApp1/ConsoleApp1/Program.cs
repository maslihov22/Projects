using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Coder
{
    class Program
    {
        private static Dictionary<string, string> LetterDic = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            bool Decode = false;
            LetterDic.Add("33.442.552.22.441.551", "А");
            LetterDic.Add("33.442.22.441.551.11", "Б");
            while (true)
            {
                Console.WriteLine("Code [C] Or Decode? [D]");
                Console.Write("Input: ");
                var Input = Console.ReadLine();
                if (Input == "D") Decode = true;
                else Decode = false;
                if (Decode)
                {
                    Console.WriteLine("Enter string to decode separate with ','");
                    var toDecode = Console.ReadLine();
                    DecoderText(toDecode);
                }
                else
                {
                    Console.WriteLine("Enter string to code");
                    var toCode = Console.ReadLine();
                    CoderText(toCode);
                }

            }
        }

        static void DecoderText(string ToDecode)
        {
            List<string> stringList = ToDecode.Split(',').ToList();
            string LetterToWrite;
            Console.Clear();
            Console.Write("DecoderResult: ");
            foreach (var test in stringList)
            {
                LetterDic.TryGetValue(test, out LetterToWrite);
                Console.Write(LetterToWrite);
            }
            Console.WriteLine();
            Console.WriteLine("Enter any key to goto to menu!");
            Console.ReadKey();
        }

        static void CoderText(string ToCode)
        {
            List<char> charList = new List<char>(ToCode.Length);
            foreach (var c in ToCode)
            {
                charList.Add(c);
            }
            Console.Clear();
            Console.Write("CoderResult: ");
            foreach (var test in charList)
            {
                var coder = LetterDic.FirstOrDefault(x => x.Value.Contains(test)).Key;
                Console.Write(coder);
                Console.Write(",");
                coder = "";
            }
            Console.WriteLine();
            Console.WriteLine("Enter any key to goto to menu!");
            Console.ReadKey();
        }
    }
}
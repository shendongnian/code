    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace test1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //ask user for the filename
                string userInput = fetchFileName("Enter the textfile you want to view: ");
    
                //test if the filename writes anything to console
                string fileContents = File.ReadAllText(userInput);
    
                string theFileContents = analyseFile(fileContents);
                //   Console.WriteLine(theFileContents);
    
                foreach (var item in tenOrMore(fileContents))
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
    
            private static IEnumerable<string> tenOrMore(string fileContents)
            {
                foreach (var item in fileContents.Split(' ', '\t', '\n', '\r'))
                {
                    if (item.Length.CompareTo(10) > 0)
    	            {
                        yield return item;
    	            }
                }
            }
    
            private static string analyseFile(string fileContents)
            {
                string str = fileContents;
                if (str.Contains("A"))
                {
                    Console.WriteLine("YES");
    
                }
                else
                {
                    Console.WriteLine("NO");
                }
                return str;
            }
    
            private static string fetchFileName(string askFileName)
            {
                Console.WriteLine(askFileName);
                string userAnswer = Console.ReadLine();
                return userAnswer;
            }
        }
    }

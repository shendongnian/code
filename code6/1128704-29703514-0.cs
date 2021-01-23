    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter a word : ");
                string word = Console.ReadLine();
    
                Console.WriteLine("The reversed word is : {0}", new string (word.Reverse().ToArray()));
                Console.ReadLine();
            }
        }
    }

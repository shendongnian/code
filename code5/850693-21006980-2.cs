    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            // First we see the input string.
            string source = "do Output.printString(\"Do you want to Hit (h) or Stand (s)?\");"
            // Here we call Regex.Match.
            Match match = Regex.Match(source, @"\\"([^\\]+)\\");
            // Here we check the Match instance.
            if (match.Success)
            {
                // Finally, we get the Group value and display it.
                string key = match.Groups[1].Value;
                Console.WriteLine("result: "+ key);
            }
            else
            {
                Console.WriteLine("nothing found");
            }
            Console.ReadLine();
        }
    }

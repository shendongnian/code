    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            var r = CheckString("112");
            Console.WriteLine(r); // false
            r = CheckString("112a");
            Console.WriteLine(r); // true
        }
        public static bool CheckString(String input)
        {
            return Regex.Match(input, @"[a-zA-Z]").Success;
            // or, as @Vlad L suggested
            //return Regex.IsMatch(input, @"[a-zA-Z]");
        }
    }

    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            string text = "x\U0001F310y";
            Console.WriteLine(text.Length); // 4
            string result = Regex.Replace(text, @"\p{Cs}", "");
            Console.WriteLine(result); // 2
        }
    }

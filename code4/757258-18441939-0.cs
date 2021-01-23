    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            string
                input = "Hello World!",
                keyword = "Hello";
            var result = Regex
                .Replace(input, keyword, m => 
                    String.Format("<b>{0}</b>", m.Value));
            Console.WriteLine(result);
        }
    }

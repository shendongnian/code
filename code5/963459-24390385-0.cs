    using System;
    using System.Text.RegularExpressions;
    public class Program
    {
        private static Regex _invalidXMLChars = new Regex(@"(?<![\uD800-\uDBFF])[\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|[\x00-\x08\x0B\x0C\x0E-\x1F\x7F-\x9F\uFEFF\uFFFE\uFFFF]", RegexOptions.Compiled);
    
        public static void Main()
        {
            var text = "assd\u000fabv";
            Console.WriteLine(_invalidXMLChars.IsMatch(text));
        }
    }

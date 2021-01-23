    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication
    {
        class Program
        {
            public static String ReplaceASCIICodesWithUTF(String target)
            {
                Regex codeSequence = new Regex(@"&#[0-9]{1,3};");
                MatchCollection matches = codeSequence.Matches(target);
                StringBuilder resultStringBuilder = new StringBuilder(target);
                foreach (Match match in matches)
                {
                    String matchedCodeExpression = match.Value;
                    String matchedCode = matchedCodeExpression.Substring(2, matchedCodeExpression.Length - 3);
                    Byte resultCode = Byte.Parse(matchedCode);
                    resultStringBuilder.Replace(matchedCodeExpression, ((Char)resultCode).ToString());
                }
                return resultStringBuilder.ToString();
            }
            static void Main(string[] args)
            {
                String rawData = "&#70;&#101;&#101;&#108;";
                Console.WriteLine(ReplaceASCIICodesWithUTF(rawData));
            }
        }
    }

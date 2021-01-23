    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string result;
                var source = @"<br><br>thestringIwant<br><br> => thestringIwant<br/> same <br/> <br/>  ";
                result = RemoveStartEndBrTag(source);
                Console.WriteLine(result);
                Console.ReadKey();
            }
    
            private static string RemoveStartEndBrTag(string source)
            {
                const string replaceStartEndBrTag = @"(^(<br>[\s]*)+|([\s]*<br[\s]*/>)+[\s]*$)";
                return Regex.Replace(source, replaceStartEndBrTag, "", RegexOptions.IgnoreCase);
            }
        }
    }

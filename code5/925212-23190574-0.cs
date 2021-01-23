    using System;
    using System.Text.RegularExpressions;
    namespace CSTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Regex re = new Regex("<a href=\"(.+)\">", RegexOptions.Compiled);
                string input = "<a href=\"www.example.com\">";
                string res = re.Replace(input, 
                    "<a href=\"javascript:window.external.notify('$1')\">");
                Console.WriteLine(res);
            }
        }
    }

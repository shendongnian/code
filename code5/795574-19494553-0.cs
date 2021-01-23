    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace RegexTester
    {
        class Program
        {
            static void Main(string[] args)
            {
                var text = @"<br>
                    For Day October 21, 2013, The following locations have been restricted<br>
                    <br>
                     No increases in nominations sourced from points west of Southeast for delivery to points east of Southeast, except for Primary Firm No-Notice nominations, will be accepted.<br>";
                var pattern = "<br>\\s*";
    
                var result = Regex.Replace(text, pattern, string.Empty);
    
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }

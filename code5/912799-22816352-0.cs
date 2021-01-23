    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {    
        static void Main()
        {
            var input = "anv749dld95hd01/01/2012ncjf739dkcju";
            var regex = new Regex(@"\d{2}/\d{2}/\d{4}");
            var match = regex.Match(input);
            if (match.Success)
            {
                Console.WriteLine("Got match: {0}", match.Value);
            }
            else
            {
                Console.WriteLine("No match found");
            }
        }
    }

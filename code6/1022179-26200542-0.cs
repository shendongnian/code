    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"/hello/\d+\b");
            var text = "/hello/1 /a/sdhdkd asjs /hello/2 ajhsd " 
                + "asjskjd skj /hello/s sajdk /hello/3 assdsfd hello/4";
            
            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine("{0} at {1}", match.Value, match.Index);
            }
        }
    }

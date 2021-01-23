    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
            class TldPatterns
            {
                private TldPatterns()
                {
                    // Prevent instantiation.
                }
    
                /**
                 * If a hostname is contained in this set, it is a TLD.
                 */
                static public string[] EXACT = new string[] {
                 "gov.uk",
                 "mil.uk",
                 "co.uk",
                 //...
         
        public class Program
        {
    
            static void Main(string[] args)
            {
                string[] urls = new[] {"www.google.com", "http://www.google.co.uk/path1/path2 ", "http://google.co.uk/path1/path2 ",
                "http://google.com", "http://google.co.in"};
                foreach (var item in urls)
                {
                    string url = item;
                    if (!Regex.IsMatch(item, "^\\w+://"))
                        url = "http://" + item;
                    var domain = GetDomain.GetDomainFromUrl(url);
                    Console.WriteLine("Original    : " + item);
                    Console.WriteLine("URL         : " + url);
                    Console.WriteLine("Domain      : " + domain);
                    Console.WriteLine("Domain Part : " + domain.Substring(0, domain.IndexOf('.')));
                    Console.WriteLine();
                }
            }
        }

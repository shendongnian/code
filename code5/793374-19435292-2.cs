    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = new List<string>() { 
    			@"5 renvan 5 /13",
                @"5 renwan 13",
                @"Terak 516  ",
                @"Terak 516/87 ",
                @"Timbron 5 827 /619",
                @"Timbron 5 980 / 69   ",
                @"Timbron 5 187 / 121"};
    
                input.ForEach(item => {
                    Match match = Regex.Match(item, @"(\d+)(\s*)?/?(\s*\d+\s*)?$", RegexOptions.IgnoreCase);
    
                    Console.WriteLine(string.Format("Input string: {0,20}\tResult House #: {1,5}\tCO:{2,5}",
                        item,
                        match.Groups[1].Value.Trim(),
                        string.IsNullOrEmpty(match.Groups[3].Value.Trim()) ? "0" : match.Groups[3].Value.Trim()));
                });
    
            }
            
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;
    
    namespace Test.Console
    {
        class Program
        {
            static void Main(string[] args)
            {
                string reference = "<div class=\"anime_info\"><div class='ctdn'>Ep 7 - <span class=\"cd_day\">3</span>d <span class=\"cd_hr\">10</span>h <span class=\"cd_min\">30</span>m </div>";
    
                var regex = "[>]Ep(\\s+)(\\d+)(\\s+)\\-(\\s+)[<]";
                var regex2 = "(\\d+)";
                foreach (var m in Regex.Matches(reference, regex))
                {
                    System.Console.WriteLine(m.ToString());
                    var m2 = Regex.Match(m.ToString(), regex2);
                    System.Console.WriteLine(m2.ToString());
                }
                System.Console.Read();
            }
        }
    }

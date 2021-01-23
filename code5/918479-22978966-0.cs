    using System.Text.RegularExpressions;
    using System;
    
    public class Program{
        public static void Main(string[] args) {
            Regex rgx = new Regex(@"^[-+]?\d*[+,]?\d+$");
            Console.WriteLine(rgx.IsMatch("20,000")); //True
            Console.WriteLine(rgx.IsMatch("20+100")); //True
            Console.WriteLine(rgx.IsMatch("20000,")); // False
            Console.WriteLine(rgx.IsMatch("20.200")); // False
        }
    }

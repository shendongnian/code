    using System.Text.RegularExpressions;
    using System.IO;
    using System;
    
    public class Program {
        public static void Main(string[] args) {
            string input = "Windows Phone 8.1 now has 'Cortana', a Siri-like feature for the platform.";
            Regex reg = new Regex("(?<!\\d)\\.(?!\\d)");
            string[] output = reg.Split(input);
            Console.WriteLine(output[0]);
        }
    }

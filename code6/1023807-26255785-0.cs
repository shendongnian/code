    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string regexStr = @"Asm_vidEmfUpdate_2 \(0\, \?unknown\?\)";
            Regex regex = new Regex(regexStr);
    
            string instr = "Asm_vidEmfUpdate_2 (0, ?unknown?)";
            MatchCollection m = regex.Matches(instr); 
            string str1 = m[0].Groups[0].Value;
            Console.WriteLine(str1);
        }
    }

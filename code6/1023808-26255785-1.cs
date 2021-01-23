    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string regexStr = @"([A-Za-z_0-9]+) \((\d+), ([^\)]+)\)";
            Regex regex = new Regex(regexStr);
    
            string instr = "Asm_vidEmfUpdate_2 (0, ?unknown?)";
            Match m = regex.Matches(instr)[0];
            foreach (Group group in m.Groups)
            {
                Console.WriteLine(group.Value);
            }
        }
    }

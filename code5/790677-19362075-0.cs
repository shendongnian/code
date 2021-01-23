    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StringSplit
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"123456789ABC
    123456789ABC";
    
                string[] lines = input.Split(new char[]{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var l in lines)
                {
                    System.Diagnostics.Debug.WriteLine(l.Substring(0, 6));
                    System.Diagnostics.Debug.WriteLine(l.Substring(6, 6));
                }
            }
        }
    }

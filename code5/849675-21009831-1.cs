    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;     // DLL support
    
    namespace Troy5
    {
        class Program
        {
            [DllImport(@"C:\CSharp\Troy5\x64\Debug\Div.dll")]
            public static extern ulong Divide (ref ulong rem, ulong dividend_low,
                                           ulong divisor);
            static void Main (string[] args)
            {
                Console.WriteLine("This is C# program");
                ulong quot, rem = 3, dividend_low = 1, divisor = 20;
                Console.WriteLine("divide (3 * 2^64 + 1) by 20");
                quot = Divide(ref rem, dividend_low, divisor);
                Console.WriteLine("quotient = {0}, remainder = {1}", quot, rem);
            }
        }
    }

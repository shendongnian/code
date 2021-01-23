    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MathWorks.MATLAB.NET.Arrays;
    using makesquare;
    [assembly: MathWorks.MATLAB.NET.Utility.MWMCROption("-nojit")] 
    
    namespace Matlabski
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    MLTestClass stuff = new MLTestClass();
                    object[] res = stuff.makesquare(1, 3);
                    Console.WriteLine(res[0].ToString());
                    Console.WriteLine("sdfsdf");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.ReadKey();
            }
        }
    }

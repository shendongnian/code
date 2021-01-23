    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace Tekkit
    {
        class Program
        {
            static void Main(string[] args)
            {
                    //make sure to add last 2 using statements
                    ProcessStartInfo start = new ProcessStartInfo("calc.exe");                              
                    Process.Start(start);//starts the process
            
            }
        }
    }

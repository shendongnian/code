    using System;
    using System.Runtime.InteropServices;
    
    class Example
    {
    
        [DllImport("your_dll_here.dll")]
        static extern int SomeFuncion1(int parm);
        static void Main()
        {
            int result = SomeFunction1(10);
        }
    }

    using System;
    using System.Runtime.InteropServices;     // DLL support
    class HelloWorld
    {
        [DllImport("TestLib.dll")]
        public static extern void DisplayHelloFromDLL ();
    
        public  void SomeFunction()
        {
            Console.WriteLine ("This is C# program");
            DisplayHelloFromDLL ();
        }
    }

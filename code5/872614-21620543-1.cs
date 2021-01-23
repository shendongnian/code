    using System;
    using System.Runtime.InteropServices;     // DLL support
    
    class HelloWorld
    {
        [DllImport("TestLib.dll")]
        public static extern void DisplayHelloFromDLL ();
    
        static void Main ()
        {
            Console.WriteLine ("This is C# program");
            DisplayHelloFromDLL ();
        }
    }

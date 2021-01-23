    using System;
    
    namespace AppWithCustomMain
    {
        class CustomMain
        {
            [STAThread]
            static void Main()
            {
                Console.WriteLine("CustomMain!");
                App.Main();
            }
        }
    }

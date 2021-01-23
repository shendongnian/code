    using System;
    using Cosmos.Compiler.Builder;
    
    namespace CosmosBoot1
    {
        class Program
        {
            #region Cosmos Builder logic
            // Most users wont touch this. This will call the Cosmos Build tool
            [STAThread]
            static void Main(string[] args)
            {
                BuildUI.Run();
            }
            #endregion
    
            // Main entry point of the kernel
            public static void Init()
            {
                var xBoot = new Cosmos.Sys.Boot();
                xBoot.Execute();
                //There's supposed to be a bit of text here. Change it to Console.WriteLine("Hello world!");
            }
        }
    }

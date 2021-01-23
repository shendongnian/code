    using System;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    public class TestIE
    {
        public static void Main()
        {
            Console.WriteLine("Creating application");
            dynamic app = Activator.CreateInstance(Type.GetTypeFromProgID("InternetExplorer.Application"));
            Console.WriteLine("Created application");
            app.Visible = true;
    
            app.OnQuit += new Action(() => {
                Console.WriteLine("Entered OnQuit");
                Marshal.ReleaseComObject(app);
                app = null;
                Console.WriteLine("Leaving OnQuit");
            });
    
            Console.WriteLine("Sleeping");
            Thread.Sleep(5000); // enough time to see if iexplore.exe is running
            Console.WriteLine("Slept");
    
            Console.WriteLine("Quitting");
            app.Quit();
            Console.WriteLine("Quit");
    
            Console.WriteLine("Sleeping");
            Thread.Sleep(5000); // enough time to see if iexplore.exe is running
            Console.WriteLine("Slept");
    
            Console.WriteLine(app == null);
        }
    }

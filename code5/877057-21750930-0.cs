    using System;
    using System.Threading;
    
    class EarlyFinalizationDemo
    {
        int x = Environment.TickCount;
        
        ~EarlyFinalizationDemo()
        {
            Test.Log("Finalizer called");
        }    
    
        public void SomeMethod()
        {
            Test.Log("Entered SomeMethod");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Thread.Sleep(1000);
            Test.Log("Collected once");
            Test.Log("Value of x: " + x);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Thread.Sleep(1000);
            Test.Log("Exiting SomeMethod");
        }
        
    }
    
    class Test
    {
        static void Main()
        {
            var demo = new EarlyFinalizationDemo();
            demo.SomeMethod();
            Test.Log("SomeMethod finished");
            Thread.Sleep(1000);
            Test.Log("Main finished");
        }
    
        public static void Log(string message)
        {
            // Ensure all log entries are spaced out
            lock (typeof(Test))
            {
                Console.WriteLine("{0:HH:mm:ss.FFF}: {1}",
                                  DateTime.Now, message);
                Thread.Sleep(50);
            }
        }
    }

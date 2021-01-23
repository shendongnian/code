    using System;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Boolean isService = false;                       // Figure it out by args, ...
            
                Thread t = new Thread(new ParameterizedThreadStart(HelperMain));
                t.IsBackground = false;
                t.Priority = ThreadPriority.Normal;
                if (isService)
                {
                    t.SetApartmentState(ApartmentState.MTA);
                }
                else
                {
                    t.SetApartmentState(ApartmentState.STA);
                }
                t.Start(args);
            }
            static void HelperMain(Object o)
            {
                Console.WriteLine(Thread.CurrentThread.GetApartmentState());
                Console.ReadLine();
            }
        }
    }

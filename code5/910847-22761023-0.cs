    using System;
    using System.Runtime.Remoting.Contexts;
    using System.Threading;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            [Synchronization]
            public class CtxObject : ContextBoundObject
            {
                public void Report(string step)
                {
                    Program.Report(step);
                }
            }
    
            public static void Main(string[] args)
            {
                Program.Report("app start");
                System.AppDomain domain = System.AppDomain.CreateDomain("New domain");
    
                var ctxOb = new CtxObject();
                ctxOb.Report("ctxOb object");
    
                domain.SetData("ctxOb", ctxOb);
                domain.DoCallBack(() => 
                {
                    Program.Report("inside another domain");
                    var ctxOb2 = (CtxObject)System.AppDomain.CurrentDomain.GetData("ctxOb");
                    ctxOb2.Report("ctxOb called from another domain");
                });
    
                Console.ReadLine();
            }
    
            static void Report(string step)
            {
                var threadDomain = Thread.GetDomain().FriendlyName;
                Console.WriteLine(
                    new
                    {
                        // Thread.CurrentContext.ContextID is only unique for the scope of domain
                        step,
                        ctx = Thread.CurrentContext.GetHashCode(),
                        threadId = Thread.CurrentThread.ManagedThreadId,
                        domain = Thread.GetDomain().FriendlyName,
                    });
            }
        }
    }

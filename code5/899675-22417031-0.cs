    using System;
    using System.Runtime.Remoting.Contexts;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            [Synchronization]
            public class MyController: ContextBoundObject
            {
                /// All access to objects of this type will be intercepted
                /// and a check will be performed that no other threads
                /// are currently in this object's synchronization domain.
    
                int i = 0;
    
                public void Test()
                {
                    Console.WriteLine(String.Format("\nenter Test, i: {0}, context: {1}, thread: {2}, domain: {3}", 
                        this.i, 
                        Thread.CurrentContext.ContextID, 
                        Thread.CurrentThread.ManagedThreadId, 
                        System.AppDomain.CurrentDomain.FriendlyName));
    
                    Console.WriteLine("Testing context...");
                    Program.TestContext();
    
                    Thread.Sleep(1000);
                    Console.WriteLine("exit Test");
                    this.i++;
                }
    
                public async Task TaskAsync()
                {
                    var context = Thread.CurrentContext;
                    var contextAwaiter = new ContextAwaiter();
                    
                    Console.WriteLine(String.Format("TaskAsync, context: {0}, same context: {1}, thread: {2}",
                        Thread.CurrentContext.ContextID,
                        Thread.CurrentContext == context,
                        Thread.CurrentThread.ManagedThreadId));
    
                    await Task.Delay(1000);
                    Console.WriteLine(String.Format("after Task.Delay, context: {0}, same context: {1}, thread: {2}",
                        Thread.CurrentContext.ContextID,
                        Thread.CurrentContext == context,
                        Thread.CurrentThread.ManagedThreadId));
    
                    await contextAwaiter;
                    Console.WriteLine(String.Format("after await contextAwaiter, context: {0}, same context: {1}, thread: {2}",
                        Thread.CurrentContext.ContextID,
                        Thread.CurrentContext == context,
                        Thread.CurrentThread.ManagedThreadId));
                }
            }
    
            // ContextAwaiter
            public class ContextAwaiter :
                System.Runtime.CompilerServices.INotifyCompletion
            {
                Context _context;
    
                public ContextAwaiter()
                {
                    _context = Thread.CurrentContext;
                }
    
                public ContextAwaiter GetAwaiter()
                {
                    return this;
                }
    
                public bool IsCompleted
                {
                    get { return false; }
                }
    
                public void GetResult()
                {
                }
    
                // INotifyCompletion
                public void OnCompleted(Action continuation)
                {
                    _context.DoCallBack(() => continuation());
                }
            }
    
            // Main
            public static void Main(string[] args)
            {
                var ob = new MyController();
    
                Action<string> newDomainAction = (name) =>
                {
                    System.AppDomain domain = System.AppDomain.CreateDomain(name);
                    domain.SetData("ob", ob);
                    domain.DoCallBack(DomainCallback);
                };
    
                Console.WriteLine("\nPress Enter to test domains...");
                Console.ReadLine();
    
                var task1 = Task.Run(() => newDomainAction("domain1"));
                var task2 = Task.Run(() => newDomainAction("domain2"));
                Task.WaitAll(task1, task2);
    
                Console.WriteLine("\nPress Enter to test ob.Test...");
                Console.ReadLine();
                ob.Test();
    
                Console.WriteLine("\nPress Enter to test ob2.TestAsync...");
                Console.ReadLine();
                var ob2 = new MyController();
                ob2.TaskAsync().Wait();
    
                Console.WriteLine("\nPress Enter to test TestContext...");
                Console.ReadLine();
                TestContext();
    
                Console.WriteLine("\nPress Enter to exit...");
                Console.ReadLine();
            }
    
            static void DomainCallback()
            {
                Console.WriteLine(String.Format("\nDomainCallback, context: {0}, thread: {1}, domain: {2}",
                    Thread.CurrentContext.ContextID,
                    Thread.CurrentThread.ManagedThreadId,
                    System.AppDomain.CurrentDomain.FriendlyName));
    
                var ob = (MyController)System.AppDomain.CurrentDomain.GetData("ob");
                ob.Test();
                Thread.Sleep(1000);
            }
    
            public static void TestContext()
            {
                var context = Thread.CurrentContext;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    Console.WriteLine(String.Format("QueueUserWorkItem, context: {0}, same context: {1}, thread: {2}",
                        Thread.CurrentContext.ContextID,
                        Thread.CurrentContext == context,
                        Thread.CurrentThread.ManagedThreadId));
                }, null);
    
                ThreadPool.UnsafeQueueUserWorkItem(_ =>
                {
                    Console.WriteLine(String.Format("UnsafeQueueUserWorkItem, context: {0}, same context: {1}, thread: {2}",
                        Thread.CurrentContext.ContextID,
                        Thread.CurrentContext == context,
                        Thread.CurrentThread.ManagedThreadId));
                }, null);
            }
        }
    }

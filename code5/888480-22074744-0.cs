    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace AsyncResultTesting
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                Console.WriteLine("Starting");
    
                
    
                for (int i = 0; i < 150; i++)            {
                    delMeth d = new delMeth(sleepMethod);
                    Console.WriteLine(string.Format("Calling the begin invoke from thread: {0} for ID: {1}", Thread.CurrentThread.ManagedThreadId.ToString(), i.ToString()));
                    IAsyncResult ar = d.BeginInvoke(i, new AsyncCallback(callbackMessage), d);
                }
                Console.ReadLine();
            }
    
            private delegate int delMeth(int id);
    
            private static int sleepMethod(int id)
            {
                Console.WriteLine(Environment.NewLine + String.Format("Thread: {0} is sleeping. Delegate id is {1}", Thread.CurrentThread.ManagedThreadId.ToString(),id.ToString()));
                Console.WriteLine(String.Format("Thread Properties IsThreadPoolThread? = {0} isThreadBackground? = {1} ThreadState: = {2}", Thread.CurrentThread.IsThreadPoolThread.ToString(), Thread.CurrentThread.IsBackground.ToString(), Thread.CurrentThread.ThreadState.ToString()));
                Console.WriteLine("");
                Thread.Sleep(10);              
                return id;
    
            }
    
            private static void callbackMessage(IAsyncResult ar)
            {
                delMeth d = (delMeth)ar.AsyncState;
                int result = d.EndInvoke(ar);
                Console.WriteLine(Environment.NewLine + "************************ END INVOKE *****************************");
                Console.WriteLine(String.Format("Delegate was just called back for id: {0}", result.ToString()));
            }
    
        }
    
    
    }

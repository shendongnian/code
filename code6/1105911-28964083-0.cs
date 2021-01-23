    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Sandbox
    {
        class Program
        {
            // some random object to lock on
            private static Object objLock;
    
            // the value we want to read
            private static int value;
    
            // entry point
            static void Main(string[] args)
            {
                value = 0;
                objLock = new Object();
    
                // Backgrond worker runs on a new thread.
                BackgroundWorker bgw = new BackgroundWorker();
                // tells the background worker object that when it is run, it should execute the bgw_DoWork method below.
                bgw.DoWork += bgw_DoWork;
                // runs the background worker
                bgw.RunWorkerAsync();
    
                getValue();
                Console.ReadKey();
            }
    
            private static void getValue()
            {
                // lock on our lock object so that no other thread can execute code that locks on the same object
                lock (objLock)
                {
                    // Relinquishes the lock on our lock object.  This thread starts blocking ("paused")
                    Monitor.Wait(objLock);
                }
                // Since the monitor Pulse(), we can continue execution.
    
                Console.WriteLine(value); // prints out 10 after the 2 second delay
            }
    
            static void bgw_DoWork(object sender, DoWorkEventArgs e)
            {
                System.Threading.Thread.Sleep(2000); // some long operation that calculates the new value
                // this locks on our lock object.  since we Wait() on the objlock in getValue(), the lock is available and we
                // can continue executing this code.
                lock (objLock)
                {
                    value = 10;
                    // This tells the thread executing getValue() that it may continue.
                    Monitor.Pulse(objLock);
                }
            }
        }
    }

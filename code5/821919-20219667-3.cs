    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    namespace Threads
    {
        class Storage
        {
            static int _number;
            public readonly static object LockNumber = new object();
            public static int Number
            {
                get
                {
                    lock (LockNumber)
                    {
                        Monitor.Pulse(LockNumber);
                        return _number;
                    }
                }
                set
                {
                    lock (LockNumber)
                    {
                        _number = value;
                        Monitor.Pulse(LockNumber);
                        Monitor.Wait(LockNumber);
                    }
                }
            }
        }
        class Counter
        {
            public delegate void Done();
            public event Done OnDone;
            public Counter()
            {
                //t.Start();
            }
            public void CounterFunction()
            {
                for (int i = 0; i < 25; i++)
                {
                    Storage.Number = i;
                }
                Storage.Number = -1;
                if (OnDone != null)
                {
                    OnDone();
                }
            }
        }
        class Printer
        {
            public Printer()
            {
                //t1.Start();
            }
            public void Print()
            {
                Boolean stop = false;
                int prevNumber = -1;
                while (!stop)
                {
                    if (Storage.Number != -1)
                    {
                        if (Storage.Number != prevNumber)
                        {
                            prevNumber = Storage.Number;
                            Console.WriteLine("Number is " + Storage.Number);
                        }
                    }
                    else
                    {
                        stop = true;
                    }
                }
            }
        }
        public partial class Check : Form //Invoking is a System.Windows.Forms function
        {
            public Thread _cThread;
            public Thread _pThread;
            static void Main()
            {
                Check ch = new Check();
            }
            public Check()
            {
                Storage s1 = new Storage();
                Counter c = new Counter();
                c.OnDone += new Counter.Done(countDone);
                Printer p = new Printer();
                _cThread = new Thread(new ThreadStart(c.CounterFunction));
                _pThread = new Thread(new ThreadStart(p.Print));
                _cThread.Start();
                _pThread.Start();
                while (true) ;
            }
            private void countDone()
            {
                if (_pThread.IsAlive)
                {
                    _pThread.Abort();
                }
                //Close the threads nicely
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.countDone)); //This says: invoke and then call countDone.
                }
            }
        }
    }

    using System;
    using System.Collections;
    using System.Threading;
    
    namespace ConsoleApplication_22516303
    {
        class Program
        {
            class AsyncLogic
            {
                public EventHandler Completed = delegate { };
    
                IEnumerable WorkAsync(Action nextStep)
                {
                    using (var timer = new System.Threading.Timer(_ => nextStep()))
                    {
                        timer.Change(0, 500);
    
                        var tick = 0;
                        while (tick < 10)
                        {
                            // resume upon next timer tick
                            yield return Type.Missing;
                            Console.WriteLine("Tick: " + tick++);
                        }
                    }
    
                    this.Completed(this, EventArgs.Empty);
                }
    
                public void Start()
                {
                    IEnumerator enumerator = null;
                    Action nextStep = () => enumerator.MoveNext();
                    enumerator = WorkAsync(nextStep).GetEnumerator();
                    nextStep();
                }
            }
    
            static void Main(string[] args)
            {
                var mre = new ManualResetEvent(false);
                var asyncLogic = new AsyncLogic();
                asyncLogic.Completed += (s, e) => mre.Set();
                asyncLogic.Start();
                mre.WaitOne();
                Console.WriteLine("Completed, press Enter to exit");
                Console.ReadLine();
            }
        }
    }

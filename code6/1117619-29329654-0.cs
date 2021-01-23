    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            
            public static void Main(string[] args)
            {
    
                example e = new example();
                e.timer();
                Console.Read();
            }
    
            public class example
            {
                public volatile int i;
                public void timer()
                {
                    TimerCallback tcb = callback;
                    Timer t = new Timer(tcb, i, 3000, 3000);
                }
    
                public void callback(object state)
                {
                    Console.WriteLine(this.i);
                    this.i++;
                }
            }
        }
    
    }

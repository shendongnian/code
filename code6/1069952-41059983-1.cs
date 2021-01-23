    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    ...
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.ShutdownEvent += Handler1;
            a.ShutdownEvent += Handler2;
            a.ShutdownEvent += Handler3;
            a.OnShutdownEvent(new EventArgs());
            Console.WriteLine("Handlers should all be done now.");
            Console.ReadKey();
        }
        static void handlerCore( int id, int offset, int num )
        {
            Console.WriteLine("Starting shutdown handler #{0}", id);
            int step = 200;
            Thread.Sleep(offset);
            for( int i = 0; i < num; i += step)
            {
                Thread.Sleep(step);
                Console.WriteLine("...Handler #{0} working - {1}/{2}", id, i, num);
            }
            Console.WriteLine("Done with shutdown handler #{0}", id);
        }
        static void Handler1(EventArgs e) { handlerCore(1, 7, 5000); }
        static void Handler2(EventArgs e) { handlerCore(2, 5, 3000); }
        static void Handler3(EventArgs e) { handlerCore(3, 3, 1000); }
    }

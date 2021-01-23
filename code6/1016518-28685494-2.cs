    using System;
    class Program
    {
        static bool tru = true;
        static void Main(string[] args)
        {
            var x = new Destructive();
            while (tru)
            {
                GC.Collect(2);
            }
            GC.KeepAlive(x); // unreachable yet has an effect on program output
        }
    }
    class Destructive
    {
        ~Destructive()
        {
            Console.WriteLine("Blah");
        }
    }

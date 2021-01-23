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
            GC.KeepAlive(x);
        }
    }
    class Destructive
    {
        ~Destructive()
        {
            Console.WriteLine("Blah");
        }
    }

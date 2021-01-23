    class Program
    {
        static void Main()
        {
            // A few objects get released by the initial GC.Collect call - the count drops from 108 to 94 objects in one test
            GC.Collect();
            // Set a breakpoint here, run these two sos commands:
            // !eeheap -gc
            // !dumpheap -stat
            for (int i = 0; i < 100000; i++)
            {
                object o = new object();
            }
            // Set a breakpoint here, run these two sos commands before this line, then step over and run them again
            // !eeheap -gc
            // !dumpheap -stat
            GC.Collect();
        }
    }

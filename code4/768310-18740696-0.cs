        static void Main()
        {
            DisplayMemory();
            GC.Collect();
            GC.WaitForFullGCComplete();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("--- New object #{0} ---", i + 1);
                object o = new object();
                GC.Collect();
                GC.WaitForFullGCComplete();
                Console.Read();
                Console.Read();
                DisplayMemory();
            }
            Console.WriteLine("--- press any key to quit ---");
            Console.WriteLine();
            Console.Read();
            Console.Read();
            GC.Collect();
            GC.WaitForFullGCComplete();
            DisplayMemory();
        }

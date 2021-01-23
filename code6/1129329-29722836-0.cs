    static void Main()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        Console.WriteLine(IntPtr.Size);
        Stopwatch MulOperatorWatch = new Stopwatch();
        Stopwatch MulMethodWatch = new Stopwatch();
        MulMethodClass.start();
        MulOperatorClass.start();
        {
            MulMethodWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MulMethodClass.start();
            }
            MulMethodWatch.Stop();
        }
        {
            MulOperatorWatch.Start();
            // Creates a new MulOperatorClass to perform the start method 100 times.
            for (int i = 0; i < 100; i++)
            {
                MulOperatorClass.start();
            }
            MulOperatorWatch.Stop();
        }
        Console.WriteLine("Operator = " + MulOperatorWatch.ElapsedMilliseconds.ToString());
        Console.WriteLine("Method = " + MulMethodWatch.ElapsedMilliseconds.ToString());
        Console.ReadLine();
    }
    public class MulOperatorClass
    {
        public static void start()
        {
            for (int i = 2; i < 15000000; i++)
            {
                if (((long)i) * ((long)i) == ((long)i))
                {
                    throw new Exception();
                }
            }
        }
    }
    public class MulMethodClass
    {
        public static void start()
        {
            for (int i = 2; i < 15000000; i++)
            {
                if (Math.BigMul(i, i) == i)
                {
                    throw new Exception();
                }
            }
        }
    }

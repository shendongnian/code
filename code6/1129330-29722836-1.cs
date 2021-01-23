    static void Main()
    {
        // Check x86 or x64
        Console.WriteLine(IntPtr.Size == 4 ? "x86" : "x64");
        // Check Debug/Release
        Console.WriteLine(IsDebug() ? "Debug, USELESS BENCHMARK" : "Release");
        // Check if debugger is attached
        Console.WriteLine(System.Diagnostics.Debugger.IsAttached ? "Debugger attached, USELESS BENCHMARK!" : "Debugger not attached");
        // High priority
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        Stopwatch MulOperatorWatch = new Stopwatch();
        Stopwatch MulMethodWatch = new Stopwatch();
        // Prerunning of the benchmarked methods
        MulMethodClass.start();
        MulOperatorClass.start();
        {
            // No useless method allocation here
            MulMethodWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                MulMethodClass.start();
            }
            MulMethodWatch.Stop();
        }
        {
            // No useless method allocation here
            MulOperatorWatch.Start();
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
        // The method is static. No useless memory allocation
        public static void start()
        {
            for (int i = 2; i < 15000000; i++)
            {
                // This condition will always be false, but the compiler
                // won't be able to remove the code
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
            // The method is static. No useless memory allocation
            for (int i = 2; i < 15000000; i++)
            {
                // This condition will always be false, but the compiler
                // won't be able to remove the code
                if (Math.BigMul(i, i) == i)
                {
                    throw new Exception();
                }
            }
        }
    }
    private static bool IsDebug()
    {
        // Taken from http://stackoverflow.com/questions/2104099/c-sharp-if-then-directives-for-debug-vs-release
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(DebuggableAttribute), false);
        if ((customAttributes != null) && (customAttributes.Length == 1))
        {
            DebuggableAttribute attribute = customAttributes[0] as DebuggableAttribute;
            return (attribute.IsJITOptimizerDisabled && attribute.IsJITTrackingEnabled);
        }
        return false;
    }

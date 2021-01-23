    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Process proc = Process.GetCurrentProcess();
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
    
                const int testCount = 1000000000;
                var stopWatch = new Stopwatch();
    
                int a = 2456;
                int b = 2456;
                stopWatch.Start();
                for (int i = 0; i < testCount; i++)
                {
                    CopyIfDifferent(ref a, b);
                }
                stopWatch.Stop();
                Console.WriteLine("int equal CopyIfDifferent ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                GC.Collect();
                Console.ReadLine();
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    a = b;
                }
                stopWatch.Stop();
                Console.WriteLine("int equal assignment ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                string c = "dfsgdgdfg";
                string d = "dfsgdgdfg";
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    CopyIfDifferent(ref c, d);
                }
                stopWatch.Stop();
                Console.WriteLine("string equal CopyIfDifferent ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    c = d;
                }
                stopWatch.Stop();
                Console.WriteLine("string equal assignment ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                int e = 2456;
                int f = 3465464;
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    CopyIfDifferent(ref e, f);
                }
                stopWatch.Stop();
                Console.WriteLine("int different CopyIfDifferent ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    e = f;
                }
                stopWatch.Stop();
                Console.WriteLine("int different assignment ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                string g = "dfsgdgdfg";
                string h = "gdfhfghfghfghf";
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    CopyIfDifferent(ref g, h);
                }
                stopWatch.Stop();
                Console.WriteLine("string different CopyIfDifferent ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
                stopWatch.Restart();
                for (int i = 0; i < testCount; i++)
                {
                    g = h;
                }
                stopWatch.Stop();
                Console.WriteLine("string different assignment ElapsedMilliseconds:{0}", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("GetTotalMemory:{0} PrivateMemorySize64:{1}  press enter to continue", GC.GetTotalMemory(true), proc.PrivateMemorySize64);
                Console.ReadLine();
            }
            public static void CopyIfDifferent(ref string vValueToCopyTo, string vValueToCopyFrom)
            {
                if (!ValuesAreEqual(vValueToCopyTo, vValueToCopyFrom))
                {
                    vValueToCopyTo = vValueToCopyFrom;
                }
            }
            public static void CopyIfDifferent(ref int vValueToCopyTo, int vValueToCopyFrom)
            {
                if (vValueToCopyTo != vValueToCopyFrom)
                {
                    vValueToCopyTo = vValueToCopyFrom;
                }
            }
            public static bool ValuesAreEqual(string vValue1, string vValue2)
            {
                if (vValue1 == null && vValue2 == null)
                {
                    return true;
                }
                if (vValue1 == null || vValue2 == null)
                {
                    return false;
                }
                return vValue1 == vValue2;
            }
        }
    }

    class FTest
    {
        static string myPath = "C:\\Users\\DRook\\Desktop\\temp\\";
        static string myPathFile = myPath + "file";
        
        public static void test()
        {
            for (int i = 0; i < 5; i++)
            {
                DoSomeWork();
                Console.WriteLine(" =  =  =  =  =  =============== =  =  =  =  =");
            }
            Console.ReadKey();
        }
        public static void testX1(string path, int index)
        {
            using (StreamWriter sw = new StreamWriter(path + index.ToString() + ".txt"))
            {
                sw.Write(index.ToString());
            }
        }
        public static void testX2(string path, int index)
        {
            if (!File.Exists(path + index.ToString() + ".txt"))
            {
                using (StreamWriter sw = new StreamWriter(path + index.ToString() + ".txt"))
                {
                    sw.Write(index.ToString());
                }
            }
        }
        static void runTestMeasure(Action<string, int> func, int count, string message, bool cleanup)
        {
            if (cleanup)
            {
                if (Directory.Exists(myPath)) Directory.Delete(myPath, true);
                System.Threading.Thread.Sleep(500);
                Directory.CreateDirectory(myPath);
                System.Threading.Thread.Sleep(500);
            }
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < count; i++)
            {
                func(myPath,i);
            }
            stopWatch.Stop();
            Console.WriteLine(message+": " + stopWatch.Elapsed);
        }
        static void DoSomeWork()
        {
            int count = 10000;
            runTestMeasure((path, ndx) => { testX1(path, ndx); },count,"Write missing file",true);
            System.Threading.Thread.Sleep(5000);
            runTestMeasure((path, ndx) => { testX2(path, ndx); }, count, "Write+Exists missing file",true);
            System.Threading.Thread.Sleep(5000);
            runTestMeasure((path, ndx) => { testX2(path, ndx); }, count, "Write existing file", false);
            System.Threading.Thread.Sleep(5000);
            runTestMeasure((path, ndx) => { testX2(path, ndx); }, count, "Write+Exists existing file", false);
        }
    }

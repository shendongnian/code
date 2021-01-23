    class Program
    {
         public struct Test
        {
            public int m_nObj;
            public object[] array;
        }
        public class Test2
        {
            public int m_nObj;
            public object[] array = new object[10];
        }
        public class Test3
        {
            public object[] array = new object[11];
        }
        static void Main(string[] args)
        {
             for (int j = 0; j < 100; j++)
            {
                GC.Collect();
                Stopwatch dtStart = new Stopwatch ();
                dtStart.Start();
                Test[] pTest = new Test[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest[i].array = new object[10];
                }
                dtStart.Stop();
                GC.Collect();
                Console.Out.WriteLine("Struct = " + dtStart.ElapsedMilliseconds);
                dtStart = new Stopwatch();
                dtStart.Start();
                Test2[] pTest2 = new Test2[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest2[i] = new Test2();
                }
                dtStart.Stop();
                GC.Collect();
                Console.Out.WriteLine("Class int = " + dtStart.ElapsedMilliseconds);
                dtStart = new Stopwatch();
                dtStart.Start();
                Test3[] pTest3 = new Test3[1000000];
                for (int i = 0; i < 1000000; i++)
                {
                    pTest3[i] = new Test3();
                }
                dtStart.Stop();
                GC.Collect();
                Console.Out.WriteLine("Class no int = " + dtStart.ElapsedMilliseconds);
                Console.Out.WriteLine("=============================");
            } 
        }
    }
    Results:
    Struct = 252.2253
    int = 396.9113
    no int = 262.9782
    
    Struct = 266.8878
    int = 399.845
    no int = 473.181
    
    Struct = 313.7979
    int = 446.8496
    no int = 411.5755
    
    Struct = 364.6454
    int = 389.0763
    no int = 553.3433
    
    Struct = 298.1766
    int = 424.2794
    no int = 441.8867

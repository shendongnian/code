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
...
            DateTime dtStart = DateTime.Now;
            Test[]  pTest = new Test[1000000];
            for(int i = 0 ; i <  1000000; i++)
            {
                pTest[i].array = new object[10];
            }
            TimeSpan span = DateTime.Now.Subtract(dtStart);
            Console.Out.WriteLine(span.TotalMilliseconds);
            dtStart = DateTime.Now;
            Test2[] pTest2 = new Test2[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                pTest2[i] = new Test2();
            }
            span = DateTime.Now.Subtract(dtStart);
            Console.Out.WriteLine(span.TotalMilliseconds);

    public static class refStructTest
    {
        struct S1
        {
            public int x;
            public int y { get; set; }
            public override string ToString()
            {
                return String.Format("[{0},{1}]", x, y);
            }
        }
        public static void test()
        {
            var s = default(S1);
            s.x = 2;
            s.y = 3;
            Object obj = s;
            var fld = typeof(S1).GetField("x");
            var prop = typeof(S1).GetProperty("y");
            fld.SetValue(obj,5);
            prop.SetValue(obj,6,null);
            s = (S1)obj;
            Console.WriteLine("Result={0}", s);
        }
    }

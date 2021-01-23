    class A_int
    {
        public class B : A_int
        {
            public void b()
            {
                Console.WriteLine(typeof(int).ToString());
            }
            public class C : A_int.B // Note!
            {
                public void c()
                {
                    Console.WriteLine(typeof(int).ToString());
                }
            }
            public class D : A_int.B
            {
                public void d()
                {
                    Console.WriteLine(typeof(int).ToString());
                }
            }
        }
    }

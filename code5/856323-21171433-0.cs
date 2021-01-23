    class A_string
    {
        public class B : A_int
        {
            public void b()
            {
                Console.WriteLine(typeof(string).ToString());
            }
            public class C : A_int.B // Note!
            {
                public void c()
                {
                    Console.WriteLine(typeof(string).ToString());
                }
            }
            public class D : A_string.B
            {
                public void d()
                {
                    Console.WriteLine(typeof(string).ToString());
                }
            }
        }
    }

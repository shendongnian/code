    class A 
    {
        private static readonly object _lock;
    
        public static void M()
        {
            lock (_lock)
            {
                Console.WriteLine("A");
            }
        }
    
        public class B : A
        {
            private static readonly object _lock = new object();
    
            static B()
            {
            }
    
            public static void M()
            {
                lock (_lock)
                {
                    Console.WriteLine("B");
                }
            }
        }
    }
    
    static void Main(string[] args)
    {
        A.B.M();
    }

    class Program
    {
        class A
        {
            private static readonly object _lock = new object();
    
            public void Validate()
            {
                lock (_lock) // NullReferenceException here...
                {
                    Console.WriteLine("Not going to make it here...");
                }
            }
    
            static A()
            {
                Console.WriteLine(_lock.ToString());
                Console.WriteLine("Now you can see that _lock is set...");
                _lock = null;
            }
        }
    
        static void Main(string[] args)
        {
            var a = new A();
            a.Validate();
        }
    }

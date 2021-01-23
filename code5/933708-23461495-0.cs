    class Program
    {   
        public static void Main()
        {
            Foo test = new Foo();
            test.Run();
            new Thread(() => { test.Loop = false; }).Start();
            do
            {            
                temp = test.Loop;
            }
            while (temp == true);
        }
    }
    
    class Foo
    {
        private volatile bool _loop = true;
        private object _syncRoot = new object();
    
        public bool Loop
        {
            // All access to the Loop value, is controlled by a lock on an instance-scoped object. I.e. when one thread accesses the value, all other threads are blocked.
            get { lock(_syncRoot) return _loop; }
            set { lock(_syncRoot) _loop = value; }
        }
        public void Run()
        {
            Task(() => 
            {
                while(_loop) // _loop is volatile, so value is not cached
                {
                    // Do something
                }
            });
        }
    }

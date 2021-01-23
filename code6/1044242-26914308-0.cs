    class Program
    {
        // MyDBContext context;
        public void Start()
        {
            Run1();
            Run2();
            ...
        }
        void Run1()
        {
            using (var context = new MyDBContext())
            {
                //...some context machination
            }
        }
        void Run2()
        {
            using (var context = new MyDBContext())
            {
                 // ...
            }
        }
    }

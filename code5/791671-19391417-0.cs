    static void Main(string[] args)
    {
        test p = new test();
    
        new Thread(() => p.SayHello("Thread One")).Start();
        new Thread(() => p.SayHello("Thread Two")).Start();
    }
    class test
    {
        static int i = 0;
        public void SayHello(string data)
        {
            i = 0;
    
            while (i < 50)
            {
                Console.WriteLine("Hello from " + data);
                i++;
            }
        }
    }

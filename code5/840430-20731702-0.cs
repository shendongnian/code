    class Something
    {
        int x = 10;
        public void DoSomething()
        {
            x++;
            Console.WriteLine("Doing something");
            Console.WriteLine("x = {0}", x);
        }
        ~Something()
        {
            Console.WriteLine("Called finalizer");
        }
    }

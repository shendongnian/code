    interface IMyInterface
    {
        void Hello();
    }
    class A : B
    {
        
    }
    class B : IMyInterface
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }

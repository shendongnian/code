    interface IShow
    {
        protected void ShowData();
    }
    class A : IShow
    {
        protected void ShowData()
        {
            Console.WriteLine("This is Class A");
        }
    }
    class B : A
    {
        protected new void ShowData()
        {
            Console.WriteLine("This is Class B");
        }
    }

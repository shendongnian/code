    interface IFooable
    {
        void Foo();
    }
    
    class Blah : IFooable
    {
        public void Foo()
        {
            Console.WriteLine("Hi from 'Blah'");
        }
    }
    
    class Bar : Blah
    {
        public void Foo()
        {
           Console.WriteLine("Hi from 'Bar'");
        }
    }

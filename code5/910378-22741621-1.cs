    class Base1 
    {
        public void Foo()
        {
            Console.WriteLine("Base1");
        }
    }
    
    class Base2 
    {
        public void Foo()
        {
            Console.WriteLine("Base2");
        }
    }
    
    class Drived : Base1, Base2
    {
    }

    class A
    {
        public virtual void F() { Console.WriteLine("A"); }
    }
    
    class B : A
    {
        public override void F() { Console.WriteLine("B"); }
    }
    
    class Program
    {
        static A GetImpl(int i)
        {
            switch(i)
            {
                case 1:
                    return new A();
                case 2:
                    return new B();
                default:
                    // whatever
            }
        }
    
        static void Main(string[] args)
        {
            var i = int.Parse(Console.ReadLine());
            A a = GetImpl(i);
            a.F();
        }
    }

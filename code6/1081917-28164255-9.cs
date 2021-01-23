    class Program
    {
        static void Main(string[] args)
        {
            var baseObj = getBase();
            baseObj.DoWork();
            Console.WriteLine("Base Name:" + baseObj.Name);
    
            var d1 = getDerived1();
            d1.DoWork();
            Console.WriteLine("Derived 1 Name:" + d1.Name);
    
            var d2 = getDerived2();
            d2.DoWork();
    
            Console.WriteLine("Derived 2 Name:" + d2.Name);
            Console.ReadKey();
        }
    
        static IBase getBase()
        {
            return new Base();
        }
    
        static IBase getDerived1()
        {
            return new Derived1();
        }
    
        static IBase getDerived2()
        {
            return new Derived2();
        }
    
    }

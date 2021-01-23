    class Base
    {
        protected int fProp;
    }
    
    class Derived : Base
    {
        public Derived()
        {
            fProp = 1;
        }
        public int Prop { get { return fProp; } }
    }
    
    class Derived2 : Base
    {
        public int Prop { get { return fProp; }  set { fProp = value; } }
    }
    
    
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                //...
                Derived obj = new Derived();
                int some = obj.Prop; //expected
                Base b = (Base)obj;
                //obj.Prop = 10; Compilation error
                Console.WriteLine(obj.Prop);
                Derived2 obj2 = new Derived2();
                obj2.Prop = 10;
                Console.WriteLine(obj2.Prop);
                Console.ReadKey();
            }
        }
    }

    class Base
    {
        protected int fProp;
        public virtual int Prop { get { return fProp; } set { fProp = value; } }
    }
    
    class Derived : Base
    {
        public Derived()
        {
            fProp = 1;
        }
        public new int Prop { get { return fProp; } private set {}  }
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
                b.Prop = 10; //oops it works
                Console.WriteLine(obj.Prop); =>it will show 10, not 1
                Console.ReadKey();
            }
        }
    }

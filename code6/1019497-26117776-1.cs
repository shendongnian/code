    class Program
    {
        static void Main(string[] args)
        {
            var obj = new DerivedClass();
            obj.SomeMethod(5);
        }
    }
    class BaseClass
    {
        public virtual void SomeMethod(int a) { Console.WriteLine("Base"); }
    }
    class DerivedClass : BaseClass
    {
    	public override void SomeMethod(int a) { Console.WriteLine("Defined in Base, overriden in Derived"); }
        public void SomeMethod(long a) { Console.WriteLine("Derived"); }
    }

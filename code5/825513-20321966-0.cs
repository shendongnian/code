    public class BaseClass
    {
        public virtual void DoWork() { Console.WriteLine("BaseClass\n"); }
        public virtual int WorkProperty
        {
            get { return 0; }
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoWork() { Console.WriteLine("DerivedClass\n"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass A2 = new DerivedClass();
    
            int a = A2.WorkProperty;
            Console.WriteLine(a);              ***//output will be "0"***
    
            // do more stuff with `a`                       
    
        }
    }

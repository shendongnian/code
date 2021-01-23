    void Main()
    {
        Base o = new Derived();
        o.Test1();
        o.Test2();
    }
    
    public class Base
    {
        public void Test1()
        {
            Debug.WriteLine("Base.Test1");
        }
    
        public virtual void Test2()
        {
            Debug.WriteLine("Base.Test2");
        }
    }
    
    public class Derived : Base
    {
        public void Test1()
        {
            Debug.WriteLine("Derived.Test1");
        }
    
        public override void Test2()
        {
            Debug.WriteLine("Derived.Test2");
        }
    }

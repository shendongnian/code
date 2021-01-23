    void Main()
    {
        IEntity e1 = new Base();
        IEntity e2 = new Derived();
        Base b1 = new Base();
        Base b2 = new Derived();
        Derived d = new Derived();
        
        e1.Test();
        e2.Test();
        b1.Test();
        b2.Test();
        d.Test();
        
    }
    
    public class Base : IEntity
    {
        public void Test()
        {
           Console.WriteLine("Base");
        }
    }
    
    public class Derived: Base, IEntity
    {
        public void Test()
        {
           Console.WriteLine("Derived");
        }
    }
    
    // Define other methods and classes here
    public interface IEntity
    {
       void Test();
    }

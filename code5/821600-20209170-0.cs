    public interface InterfaceA 
    {
        string PropertyA {get;}
    }
    public interface InterfaceB
    {
        string PropertyB {get;}
    }
    public abstract class BaseClassForOthers : InterfaceA, InterfaceB
    {
        private string PropertyA {get; private set;}
        private string PropertyA {get; private set;}
        public BaseClassForOthers (string a, string b)
        {
            PropertyA  = a;
            PropertyB  = b;
        }
    
    }
    public class SubClass : BaseClassForOthers 
    {
        public SubClass (string a, string b)
            : base(a, b)
        {
        }
    
    }

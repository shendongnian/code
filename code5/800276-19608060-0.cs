    public interface IFoo
    {
        int Value { get; set; }
    }
    
    public abstract class FooBase : IFoo
    {
        public abstract int Value { get; set; }
        
        protected void ProtectedMethod()
        {
        }
    }
    
    public class Foo : FooBase
    {
        public int Value { get; set; }
    }

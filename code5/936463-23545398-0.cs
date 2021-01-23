    public interface IFoo
    {
       void Bar();
    }
    
    public class FooImpl
    {
        void IFoo.Bar()
        {
           Console.WriteLine("I am somewhat private.")
        }
    
        private void Bar()
        {
           Console.WriteLine("I am private.")
        }
    
    }

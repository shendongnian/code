    public abstract class Base<T> where T: Base<T>
    {
        public T ClassReturn
        {
            get { return (T)this; }
        }
    }
    
    public class Child1 : Base<Child1>
    {
    }
    
    public class Child2 : Base<Child2>
    {
    }

    public abstract class BaseClass<T> where T : BaseClass<T>
    {
        public T Method1()
        {
            //Do stuffs
            return (T)this;//doesnt work
        }
    }  
    public class InheritedClass : BaseClass<InheritedClass>
    {
        public InheritedClass Method2()
        {
            //Do stuffs
            return this;
        }
    }

    public abstract class BaseClass<T> where T : BaseClass<T>
    {
        public T Method1()
        {
            //Do stuffs
            // We are sure any instance of this class is T : BaseClass<T>. 
            // Only exception might be direct instance of BaseClass<T> and that's why we made BaseClass abstract.
            return (T)this;
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

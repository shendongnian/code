    public abstract class BaseClass<T>
    {
        public T CommonMethod()
        {
            //Common code
            T result = CustomMethod(); //Call child method
            return result;
        }
        internal abstract T CustomMethod();
    }
    public class ChildClass : BaseClass<MyDTO>
    {
        internal override MyDTO CustomMethod()
        {
            //Custom Code, specific to child class
        }
    }

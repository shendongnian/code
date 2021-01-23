    public abstract class B
    {
        // Common operations which don't depend on the constructor parameter
    }
    public class B<T> : B where T : A, I2
    {
        public B(T item)
        {
        }
    }

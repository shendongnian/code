    public abstract class AFoo<T> : IFoo
    {
        // Change the signature without renaming
        abstract bool IFoo.Bar(string foo); 
        public abstract bool Bar(T foo);
    }

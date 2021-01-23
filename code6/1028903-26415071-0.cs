    public abstract class AFoo<T> : IFoo
    {
        // Change the signature without renaming
        public abstract bool Bar(string foo, string baz); 
        public abstract bool Bar(T foo);
    }

    public class My<T, S> where S : struct
    {
        public My(Nullable<S> g, T t)
        {
            // code that DOES NOT use S in any way
        }
    }

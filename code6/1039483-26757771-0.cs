    public class Class<T> where T : class
    {
        public void Method<U> where U : T, new()
        {
            // ...
        }
    }

    public class Example
    {
        private static readonly HashSet<Type> supportedTypes = new HashSet<Type>
        {
            typeof(int),
            typeof(double),
            typeof(float),
            typeof(string),
            typeof(DateTime),
        };
        public T MyMethod<T>()
        {
            if (!this.supportedTypes.Contains(typeof(T))
            {
                throw new NotSupportedException();
            }
            // ...
        }
    }

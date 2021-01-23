    public class Nullable<T> where T : class
    {
        public T Value { get; set; }
        public Nullable(T initial)
        {
            this.Value = initial;
        }
    }

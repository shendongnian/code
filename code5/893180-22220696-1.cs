    abstract class Parent<T>
    {
        protected void Add(DataTable dt) { ... }        // the real business logics
        public abstract void AddRaw(T anything);
    }

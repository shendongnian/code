    public interface IThing
    {
        object Get();
    }
    public interface IThing<T> : IThing
    {
        T Get();
    }
    public class Thing<U> : IThing<U>
    {
        private U u;
        public object Get
        {
            get
            {
                return this.Get();
            }
        }
        public U Get<U>()
        {
            get
            {
                return this.u;
            }
        }
    }

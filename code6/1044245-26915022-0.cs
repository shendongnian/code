    public abstract class Entity<T> : Entity
    {
        public new T Id
        {
            get { return (T)base.Id; }
            set { base.Id = value; }
        }
    }

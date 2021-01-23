	public abstract class ListItemViewModel<T>
    {
        public bool Insert { get; set; }
        public bool Delete { get; set; }
        public abstract bool Equals(T model);
        public virtual void OnRemove(T model) { }
        public virtual void OnAdd(T model) { }
        public virtual void OnEdit(T model) { }
    }

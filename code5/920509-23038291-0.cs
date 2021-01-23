    public class Ref<T>
    {
        public virtual T Value{get;set;}
        public Ref() { }
        public Ref(T initialValue)
        {
            Value = initialValue;
        }
    }
    public class RefProperty<T> : Ref<T>
    {
        public Func<T> Getter;
        public Action<T> Setter;
        public override T Value
        {
            get { return Getter(); }
            set { Setter(value); }
        }
        public RefProperty(Func<T> getter, Action<T> setter)
        {
            Getter = getter;
            Setter = setter;
        }
    }

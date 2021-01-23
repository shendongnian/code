    public class PropertyWrapper<T>
    {
        private Func<T> getter;
        private Action<T> setter;
        public PropertyWrapper(PropertyInfo property, object instance)
        {
            if (!typeof(T).IsAssignableFrom(property.PropertyType))
                throw new ArgumentException("Property type doesn't match type supplied");
            setter = value => property.SetValue(instance, value);
            getter = () => (T)property.GetValue(instance);
        }
        public PropertyWrapper(Func<T> getter, Action<T> setter)
        {
            this.setter = setter;
            this.getter = getter;
        }
        public T Get()
        {
            return getter();
        }
        public void Set(T value)
        {
            setter(value);
        }
        public T Value
        {
            get { return getter(); }
            set { setter(value); }
        }
    }

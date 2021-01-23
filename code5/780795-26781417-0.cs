    public class PropertyAccessor<TEntity,TProperty>
    {
        private readonly TEntity _nom;
        Func<TEntity, TProperty> _getter;
        Action<TEntity, TProperty> _setter;
        public PropertyAccessor(Func<TEntity, TProperty> getter, Action<TEntity, TProperty> setter, TEntity nom)
        {
            _getter = getter;
            _setter = setter;
            _nom = nom;
        }
        public object Value // the return type can be changed to TProperty
        {
            get { return _getter(_nom); }
            set { _setter(_nom, (TProperty)value); }
        }
    }

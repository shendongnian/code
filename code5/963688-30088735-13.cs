    public class DefaultBuilderFor<T> : IImmutableBuilderFor<T> where T : class, IImmutableOf<T>
    {
        private static readonly IDictionary<string, Tuple<Type, Action<T, object>>> _setters;
        private List<Action<T>> _mutations = new List<Action<T>>();
        static DefaultBuilderFor()
        {
            _setters = GetFieldSetters();
        }
        public DefaultBuilderFor(T instance)
        {
            Source = instance;
        }
        public T Source { get; private set; }
        public IImmutableBuilderFor<T> Set<TFieldType>(string fieldName, TFieldType value)
        {
            // Notes: error checking omitted & add what to do if `TFieldType` is not "correct".
            _mutations.Add(inst => _setters[fieldName].Item2(inst, value));
            return this;
        }
        public IImmutableBuilderFor<T> Set<TFieldType>(string fieldName, Func<T, TFieldType> valueProvider)
        {
            // Notes: error checking omitted & add what to do if `TFieldType` is not "correct".
            _mutations.Add(inst => _setters[fieldName].Item2(inst, valueProvider(inst)));
            return this;
        }
        public IImmutableBuilderFor<T> Set<TFieldType>(Expression<Func<T, TFieldType>> fieldExpression, TFieldType value)
        {
            // Error checking omitted.
            var memberExpression = fieldExpression.Body as MemberExpression;
            return Set<TFieldType>(memberExpression.Member.Name, value);
        }
        public IImmutableBuilderFor<T> Set<TFieldType>(Expression<Func<T, TFieldType>> fieldExpression, Func<TFieldType, TFieldType> valueProvider)
        {
            // Error checking omitted.
            var memberExpression = fieldExpression.Body as MemberExpression;
            var getter = fieldExpression.Compile();
            return Set<TFieldType>(memberExpression.Member.Name, inst => valueProvider(getter(inst)));
        }
        public T Build()
        {
            var result = (T)Source.Clone();
            _mutations.ForEach(x => x(result));
            return result;
        }
        private static IDictionary<string, Tuple<Type, Action<T, object>>> GetFieldSetters()
        {
            // Note: can be optimized using delegate setter creation (IL). 
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => !x.IsLiteral)
                .ToDictionary(
                    x => x.Name,
                    x => SetterEntry(x.FieldType, (inst, val) => x.SetValue(inst, val)));
        }
        private static Tuple<Type, Action<T, object>> SetterEntry(Type type, Action<T, object> setter)
        {
            return Tuple.Create(type, setter);
        }
    }

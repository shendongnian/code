    public class TypeConverter
    {
        private Dictionary<KeyValuePair<Type, Type>, Delegate> _map = new Dictionary<KeyValuePair<Type, Type>, Delegate>();
        public void Register<TIn, TOut>(Converter<TIn, TOut> converter)
        {
            _map.Add(new KeyValuePair<Type,Type>(typeof(TIn),typeof(TOut)), converter);
        }
        public T Convert<T>(object o)
        {
            Type inputType = o.GetType();
            Delegate converter = null;
            KeyValuePair<Type, Type> mapKey = new KeyValuePair<Type, Type>(inputType, typeof(T));
            if (_map.TryGetValue(mapKey, out converter))
                return (T)converter.DynamicInvoke(o);
            throw new NotSupportedException(String.Format("No converter available for {0} to {1}", o.GetType().Name, typeof(T).Name));
        }
    }

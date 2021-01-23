    public class ObjectConverter
    {
        private Dictionary<Type, Func<object, object>> m_Conversions = new Dictionary<Type, Func<object, object>>();
        public void AddConversion<TOut>(Func<object, TOut> conversion) 
        {
            // need this to support TOut as value type. 
            m_Conversions[typeof(TOut)] = obj => conversion(obj);
        }
        public T Convert<T>(object value)
        {
            return (T) Convert(value, typeof(T));
        }
        object Convert(object value, Type type)
        {
            var conversion = m_Conversions[type];
            return conversion(value);
        }
    }

    public class TypeConverterHelper
    {
        private IList<object> types;
    
        public ConvertToType<T> GetConverter<T>()
        {
            return types.OfType<ConvertToType<T>>.FirstOrDefault();
        }
    }

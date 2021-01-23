    namespace System
    {
        public static class ObjectExtensions
        {
            public static T ChangeType<T<(this object value) 
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return converter != null && converter.CanConvertFrom(value.GetType()) 
                    ? converter.ConvertFrom(value) : default(T);        
            }
        }
    }

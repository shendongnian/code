    public static class StringExtension
    {
        public static T ConvertTo<T>(this string o)
        {
            
            if (typeof (T) == typeof (Int32))
                return (T) (object) Int32.Parse(o);
            if (typeof (T) == typeof (Int16))
                return (T) (object) Int16.Parse(o);
            if (typeof(T) == typeof(Double))
                return (T) (object)Double.Parse(o);
            if (typeof(T) == typeof(Boolean))
                return (T) (object)Boolean.Parse(o);
            if (typeof(T) == typeof(Decimal))
                return (T) (object)Decimal.Parse(o);
            throw new ApplicationException("Cannot convert to type " + typeof(T));
        }
    }

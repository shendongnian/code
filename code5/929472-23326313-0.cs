    public static class Converter
    {
        public static T ConvertTo<T>(this object source) where T :class 
        {
            if (source is T)
            {
                return (T) source;
            }
            else
            {
                return null; // or throw exception
            }
        }
    }

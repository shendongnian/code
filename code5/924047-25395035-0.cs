    public static class ExtensionMethods
    {
        public static TR DefaultIfNull<T, TR>(this T source, Expression<Func<T, TR>> expr, TR defaultValue = default(TR))
        {
            TR result = defaultValue;
    
            try
            {
                result = expr.Compile().Invoke(source);
            }
            catch (NullReferenceException)
            {
                // DO NOTHING
            }
    
            return result;
        }
    }

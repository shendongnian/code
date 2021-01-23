        public static T ConvertTo<T>(object value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                return (T)(typeof(T).IsValueType ? Activator.CreateInstance(typeof(T)) : null);
            }
            
        }

    public static class EnumHelper<T>
    {
        public static IDictionary<string, T> GetValues(bool ignoreCase)
        {
            var enumValues = new Dictionary<string, T>();
            foreach (FieldInfo fi in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                string key = fi.Name;
                var display = fi.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (display != null)
                    key = (display.Length > 0) ? display[0].Name : fi.Name;
                if (ignoreCase)
                    key = key.ToLower();
                
                if (!enumValues.ContainsKey(key))
                    enumValues[key] = (T)fi.GetRawConstantValue();
            }
            return enumValues;
        }
        public static T Parse(string value)
        {
            T result;
            try
            {
                result = (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                result = ParseDisplayValues(value, true);
            }
            
            return result;
        }
        private static T ParseDisplayValues(string value, bool ignoreCase)
        {
            IDictionary<string, T> values = GetValues(ignoreCase);
            string key = null;
            if (ignoreCase)
                key = value.ToLower();
            else
                key = value;
            if (values.ContainsKey(key))
                return values[key];
                
            throw new ArgumentException(value);
        }
    }

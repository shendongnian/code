        public static T Parse<T>(object value)
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T));
            bool isNullable = underlyingType != null;
            if (!typeof(T).IsEnum && !isNullable)
                throw new ArgumentException("T must be an Enum type.");
            if (value == null || value == DBNull.Value)
            {
                if (isNullable)
                    return (T)value;
                throw new ArgumentNullException("value");
            }
            if (value is String)
                return (T)Enum.Parse(underlyingType ?? typeof(T), value.ToString());
            if (!value.GetType().IsValueType)
                throw new ArgumentException("value must be a primitive type", "value");
            return (T)Enum.ToObject(underlyingType ?? typeof(T), value);
        }

        public static T Parse<T>(Object value)
        {
            Boolean isNullable = typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>);
            if (!isNullable && !typeof(T).IsEnum)
            {
                throw new ArgumentException();
            }
            if (value == null || value == DBNull.Value)
            {
                throw new ArgumentException();
            }
            if (!(value is String))
            {
                return (T) Enum.ToObject(typeof (T), value);
            }
            if (!isNullable)
            {
                return (T) Enum.Parse(typeof (T), value.ToString());
            }
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T));
            try
            {
                return (T)Enum.Parse(underlyingType, value.ToString());
            }
            catch (ArgumentException)
            {
                return default(T);
            }
        }

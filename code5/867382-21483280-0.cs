    public object ToEnum<T>(object value)
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                int numberVal;
                if (!int.TryParse(value.ToString(), out numberVal) && value.GetType() != typeof(string))
                {
                    return null;
                }
                value = numberVal;
                if (Enum.IsDefined(type, value))
                {
                    T result = (T)Enum.Parse(type, value.ToString());
                    return result;
                }
            }
            return null;
        }

    public static string GetDescription<T>(string value)
            {
                Type type = typeof(T);
                if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(type);
                }
    
                T enumerator = (T)Enum.Parse(type, value);
    
                FieldInfo fi = enumerator.GetType().GetField(enumerator.ToString());
    
                DescriptionAttribute[] attributtes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
                if (attributtes != null && attributtes.Length > 0)
                    return attributtes[0].Description;
                else
                    return enumerator.ToString();
            }

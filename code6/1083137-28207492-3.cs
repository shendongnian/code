    public static void ShallowConvert<T, U>(this T parent, U child)
    {
        foreach (PropertyInfo property in parent.GetType().GetProperties())
        {
            if (property.CanWrite)
            {
                property.SetValue(child, property.GetValue(parent, null), null);
            }
        }
    }

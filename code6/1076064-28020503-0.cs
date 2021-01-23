    public static dynamic AppendProperty<T>(this object value, string propertyName, T newValue)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));
            expando.Add(propertyName, newValue);
            return expando as ExpandoObject;
        }

    public Dictionary<String, Object> Dyn2Dict(dynamic dyunObj)
    {
         var dictionary = new Dictionary<string, object>();
         foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
         {
            object obj = propertyDescriptor.GetValue(dynObj);
            dictionary.Add(propertyDescriptor.Name, obj);
         }
         return dictionary;
    }

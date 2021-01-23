    public object DoSomething(Type type, string propertyName)
    {
         var somethingWithProperty = Activator.CreateInstance(type, null);
         foreach (PropertyInfo property in somethingWithProperty.GetType().GetProperties())
         {
            if (property.Name == propertyName)
            {
                return property.GetValue(somethingWithProperty, null);
            }
         }
        throw new ArgumentException(string.Format("No property was found was found with this on [{0}] with propertyname [{1}]", type, propertyName));
    }

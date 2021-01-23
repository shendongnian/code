    List<object> privatePropertyValues = new List<object>();
    foreach (PropertyInfo propertyInfo in this.GetType().GetProperties(
        BindingFlags.NonPublic | BindingFlags.Instance))
    {
        //Console.WriteLine("{0}  Type: {1},  Value: {2}", propertyInfo.Name, 
        //  propertyInfo.PropertyType, propertyInfo.GetValue(this));
        privatePropertyValues.Add(propertyInfo.GetValue(this));
    }

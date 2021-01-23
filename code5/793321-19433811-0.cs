    private object Eval(KeyValuePair<string, object> df)
    {
        var properties = df.Key.Split('.');
        //line below just creates the root object (Person), you could replace it with whatever works in your example
        object root = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == properties.First()));
        var temp = root;
            
        for (int i = 1; i < properties.Length - 1; i++)
        {
            var propertyInfo = temp.GetType().GetProperty(properties[i]);
            var propertyInstance = Activator.CreateInstance(propertyInfo.PropertyType);                
            propertyInfo.SetValue(temp, propertyInstance, null);
 
            temp = propertyInstance;
        }
        temp.GetType().GetProperty(properties.Last()).SetValue(temp, df.Value, null);
        return root;
    }

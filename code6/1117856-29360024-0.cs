    System.Reflection.PropertyInfo[] pis = zone.GetType().GetProperties();
    foreach (var prop in pis)
    {
        if (prop.PropertyType.Equals(typeof(string))) 
        {
            string key = prop.Name;
            string value = (string)prop.GetValue(zome, null);
            dict.Add(key, value); //the type of dict is Dictionary<str,str>
        }
    }

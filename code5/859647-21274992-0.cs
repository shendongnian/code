    static void Main(string[] args)
    {
        MyVehicles vehicles = new MyVehicles();
        Type objectToInspectType = vehicles.GetType();
        PropertyInfo[] propertyInfos = objectToInspectType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        foreach (PropertyInfo item in propertyInfos)
        {
            Type propertyType = item.PropertyType;
            object value = item.GetValue(vehicles, null);
            if (value != null)
                propertyType = value.GetType();
            Console.WriteLine(propertyType.Name); 
        }
        Console.ReadKey();
    }

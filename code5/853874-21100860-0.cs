    public static void saveAllFiles(Context context)
    {
        var objectTypes = new List<Type> {typeof (int), typeof (string)}; 
        foreach(Type objectType in objectTypes)
        {
            var properties = objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var dataSetObjects = context.Where(x => x.GetType() == objectType);
            foreach(var dataSetObject in dataSetObjects)
            {
                foreach( var property in properties )
                {
                    var value = property.GetValue(dataSetObject);
                    var name = property.Name;
                }                   
            }
        }
    }

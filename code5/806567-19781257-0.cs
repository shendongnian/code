    //This is just a generic wrapper for the other Reflect method
    private static Dictionary<string, string> Reflect<TModel>(TModel Model)
    {
      return Reflect(Model.GetType(), Model);
    }
    private static Dictionary<string, string> Reflect(Type Type, object Object)
    {
      var result = new Dictionary<string, string>();
      var properties = Type.GetProperties();
      foreach (var property in properties)
      {
        if (
          property.GetCustomAttributes(typeof(ManyToManyAttribute), true).Any() &&
          property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
        {
          var genericType = property.PropertyType.GetGenericArguments().FirstOrDefault();
          var listValue = (IEnumerable)property.GetValue(Object);
          int i = 0;
          foreach (var value in listValue)
          {
            var childResult = Reflect(genericType, value);
            foreach (var kvp in childResult)
            {
              var collectionName = property.Name;
              var index = i;
              var childPropertyName = kvp.Key;
              var childPropertyValue = kvp.Value;
              var flattened = string.Format("{0}[{1}].{2}", collectionName, i, childPropertyName);
              result.Add(flattened, childPropertyValue);
            }
            i++;
          }
        }
        else
        {
          result.Add(property.Name, property.GetValue(Object).ToString());
        }
      }
      return result;
    }

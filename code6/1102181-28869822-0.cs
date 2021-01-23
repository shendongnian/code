    public static object CreateObject(IDictionary<string, object> valueDictionary)
    {
      Dictionary<string, object> values = new Dictionary<string, object>();
    
      foreach (KeyValuePair<string, object> pair in valueDictionary)
      {
          if (pair.Value != null && pair.Value.GetType() == typeof(Dictionary<string, object>))
          {
              // Create object and add
              object o = CreateObject(pair.Value as IDictionary<string, object>);
              values.Add(pair.Key, o);
          }
          else if (pair.Value != null && pair.Value.GetType() == typeof(List<IDictionary<string, object>>))
          {
              // Get first dictionary entry
              IDictionary<string, object> firstDictionary = ((IEnumerable<IDictionary<string, object>>)pair.Value).First();
    
              // Get the base object
              object baseObject = CreateObject(firstDictionary);
    
              // Create a new array based off of the base object
              Array anonArray = Array.CreateInstance(baseObject.GetType(), 1);
    
              // Return like the others
              values.Add(pair.Key, anonArray);
          }
          else
          {
              values.Add(pair.Key, pair.Value);
          }
      }
    
      Dictionary<string, Type> typeDictionary = values.ToDictionary(kv => kv.Key, kv => kv.Value != null ? kv.Value.GetType() : typeof(object));
    
      Type anonymousType = CreateType(typeDictionary);
    
      return CreateObject(values, anonymousType);
    }

    static Dictionary<string, string> GetAttributeDictionary(object value)
    {
      var dictionary = new Dictionary<string, string>();
    
      var type = value.GetType();
      var customAttributes = type.GetCustomAttributes(true);
      
      foreach (var attribute in customAttributes)
      {
        if (attribute is VisibilityAttribute)
        {
           var visibilityAttribute = attribute as VisibilityAttribute;
           dictionary["Visibility"] = visibilityAttribute.Visibility;
        }
    
        // Process other custom attributes...
      }
    
      return dictionary;
    }

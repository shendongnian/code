    public static object With(this IDictionary<string, object> obj, IDictionary<string,object> additionalProperties)
    {
      foreach (var name in additionalProperties.Keys)
        obj[name] = additionalProperties[name];
      return obj;
    }

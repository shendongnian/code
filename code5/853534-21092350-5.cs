    static void fetchProperties(Object instance, List<ObjectField> fields)
    {
      foreach(var pinfo in instance.GetType().GetProperties())
      {
        if(pinfo.PropertyType.IsArray)
        {
          ... // Code described above
        }
        else if(pinfo.PropertyType.GetCustomAttributes(typeof(SomeAttribute), false).Any())
          // Go the next level
          fetchProperties(pinfo.GetValue(instance), fields);
        else
        {
          ... // Do normal code
        }
        
      }
    }

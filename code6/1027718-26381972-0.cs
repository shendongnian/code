    public void ClearString(IEnumerable<object> stuffToClear)
    {
      // go through all the objects to clear
      foreach (var item in stuffToClear)
      {
        // get the properties to clear
        var props = from prop in item.GetType().GetProperties()
                    where prop.PropertyType == typeof(string) // or another type or filter
                    select prop;
        for (var p in props)
        {
          // clear it
          p.SetValue(item, string.Empty);
        }
      }
    }

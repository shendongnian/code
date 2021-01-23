    public static IEnumerable<T> Filter<T>(IEnumerable<T> source, string searchStr)
    {
      var searchStrLower = searchStr.ToLower();
      var propsToCheck = typeof(T).GetProperties().Where(a => a.PropertyType == typeof(string) && a.CanRead);
    
      return source.Where(obj => {
        foreach (PropertyInfo prop in propsToCheck)
        {
          string value = (string)prop.GetValue(obj);
          if (value != null && value.ToLower().Contains(searchStrLower)) return true;
        }
        return false;
      });
    }

    public static List<T> ConvertArrayListToList<T>(BusinessObjectCollection collection)
    {
        var list = new List<T>();
        foreach(object obj in collection)
        {
           try
           {
               T newObj = (T)Convert.ChangeType(obj, typeof(T));
               list.Add(newObj);
           }
           catch
           {
           }
        }
      
        return list;
    }    
    

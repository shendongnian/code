    if(obj is IEnumerable)
    {
         foreach(var item in (IEnumerable)obj)
         {
              Type type = item.GetType();
              PropertyInfo[] properties = type.GetProperties();
              foreach(PropertyInfo p in properties)
                  sb.Append("{0},{1}", p.Name, p.GetValue(item,null));
         } 
    }

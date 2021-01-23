    static string FindHashCode(object o, int hashCode)
    {
    	return FindHashCodeImpl(o,hashCode, o.GetType().Name);
    }
    static string FindHashCodeImpl(object o, int hashCode, string path)
    {
        var type = o.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var propValue = property.GetValue(o);
            var propValueType = propValue.GetType();
            if(propValueType.IsClass)
            {
               return FindHashCodeImpl(propValue, hashCode, path+" > "+property.Name);
            }
            else
            {
               if(propValue.GetHashCode()==hashCode)
               {
                  return path+" > "+property.Name+".hashcode = "+hashCode;
               }
            }
        }
        return "";
    }

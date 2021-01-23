    static string FindHashCode(object o, int hashCode)
    {
    	return FindHashCodeImpl(o,hashCode, o.GetType().Name);
    }
    static string FindHashCodeImpl(object o, int hashCode, string partialPath)
    {
        var type = o.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var propValue = property.GetValue(o);
            if (propValue.GetHashCode() == hashCode)
            {
                return partialPath + " > " + property.Name + ".hashcode = " + hashCode;
            }
    
            var path = FindHashCodeImpl(propValue, hashCode, partialPath + " > " + property.Name);
            if (path != null)
            {
                return path;
            }
        }
        return null;
    }

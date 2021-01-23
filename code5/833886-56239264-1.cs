    private string ObjectToString(object obj, int indent = 0)
    {
        if (obj is null)
        {
            return "";
        }
    
        var sb = new StringBuilder();
        string indentString = new string(' ', indent);
        Type objType = obj.GetType();
    
        foreach (PropertyInfo property in objType.GetProperties())
        {
            object propValue = property.GetValue(obj);
            var elems = propValue as IList;
    
            if (elems != null)
            {
                foreach (var item in elems)
                {
                    sb.Append($"{indentString}- {property.Name}\n");
                    sb.Append(ObjectToString(item, indent + 4));
                }
            }
            else if (property.Name != "ExtensionData")
            {
                sb.Append($"{indentString}- {property.Name}={propValue}\n");
    
                if (property.PropertyType.Assembly == objType.Assembly)
                {
                    sb.Append(ObjectToString(propValue, indent + 4));
                }
            }
        }
    
        return sb.ToString();
    }

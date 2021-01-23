    public static string GetValueFromProperty(this object obj, string Name)
    {
        string[] names = Name.Split('.');
        object currentObj = obj;
        string value = null;
        for (int i = 0; i < names.Length; i++)
        {
            string name = names[i];
            PropertyInfo prop = currentObj.GetType().GetProperty(name);
            if (prop == null)
                break;
            object propValue = prop.GetValue(currentObj, null);
            if (propValue == null)
                break;
            if (i == names.Length - 1)
                value = (string)propValue;
            else
                currentObj = propValue;
        }
        return value ?? string.Empty;
    }

    public static Dictionary<string, object> AnonymousToDictionary(object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            if (value != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(value))
                {
                    object obj2 = descriptor.GetValue(value);
                    dic.Add(descriptor.Name, obj2);
                }
            }
            return dic;
        }
       public static string NamedStringFormatSQL(this string aString, object replacements)
            {
                Dictionary<string, object> keyValues = AnonymousToDictionary(replacements);
                foreach (var item in keyValues)
                {
                    string val = item.Value == null ? "null" : item.Value.ToString();
                    aString = aString.Replace("@" + item.Key, val);
                }
                return aString;
    
            }

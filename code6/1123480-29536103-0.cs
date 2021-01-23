    public static object GetPropertyValue(object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
                obj = prop.GetValue(obj, null);
            return obj;
        }
        public static object CreateObject(object employee, List<string> fields)
        {
            var ret = new Dictionary<string,object>(); 
            foreach(var property in fields)ret.Add(property, GetPropertyValue(employee, property));
            return ret;
        }

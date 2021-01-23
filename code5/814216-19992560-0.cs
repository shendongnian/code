    public static T ToType<T>(this object obj, IDictionary<string, string> maps)
    {
        //create instance of T type object:
        var tmp = Activator.CreateInstance(typeof(T).Assembly.FullName, typeof(T).ToString());
        foreach (var map in maps)
        {
            try
            {
                PropertyInfo source = obj.GetType()
                    .GetProperty(map.Value);
                tmp.Unwrap().GetType().GetProperty(map.Key)
                    .SetValue(tmp.Unwrap(), source.GetValue(obj, null), null);
            }
            catch
            {
                throw new ArgumentException("Error converting to Type: " + typeof(T));
            }
        }
        return (T)tmp.Unwrap();
    }

    public static T Read<T>(string variable)
    {
        object value = HttpContext.Current.Session[variable];
        if(!typeof(T).IsValueType && value == null)
        {
            //if it is not value type you can return new instance.
            return ((T)Activator.CreateInstance(typeof(T)));
        }        
        else if (value == null)
            return default(T);
        else 
        else
            return ((T)value);
    }

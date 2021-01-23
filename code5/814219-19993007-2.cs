    public static object ToType<T>(this object obj, IDictionary<string,string> maps) where T : new()
    {
        //create instance of T type object:
        T tmp = new T();
    
		Type objType = obj.GetType();
		Type tType = typeof(T);
		
        foreach( var map in maps) {
            try 
            {   
                PropertyInfo source = objType.GetProperty(map.Value);
    
                tType.GetProperty(map.Key)
                    .SetValue(tmp, source.GetValue(obj, null), null);
            }
            catch 
            {
                throw new ArgumentException("Error converting to Type: "+ tType);
            }
        }
    
        return tmp;
    }

    public static object ToType<T>(this object obj, IDictionary<string,string> maps) {
        //create instance of T type object:
        T tmp = Activator.CreateInstance<T>(); 
    
        foreach( var map in maps) {
            try 
            {   
                PropertyInfo source = obj.GetType()
                    .GetProperty(map.Value);
    
                tmp.Unwrap().GetType().GetProperty(map.Key)
                    .SetValue(tmp.Unwrap(), source.GetValue(obj, null), null);
            }
            catch 
            {
                throw new ArgumentException("Error converting to Type: "+ typeof(T));
            }
        }
    
        return tmp.Unwrap();
    }

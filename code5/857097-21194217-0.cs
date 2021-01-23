    public static DeepObject GetNewData<T>(params Action<T>[] actions) 
     where T : DeepObject, //restrict user only inheritors of DeepObject 
               new()       //and require constructor
    {
        var data = new T(); 
    
        foreach (var action in actions)
        {
            action(data); 
        }
    
        return data; 
    }

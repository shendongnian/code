    public string getKey<T>() where T :new()
       {
           T _obj = new T();           
           return context.CreateEntityKey(_obj.ToString().Split('.')[2], _obj).EntityKeyValues[0].Key;
       }

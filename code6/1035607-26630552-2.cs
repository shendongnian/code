    public void foobar(Foo f) 
    {
        var type = f.GetType();
        var field = type.GetFields(BindigFlags.Instance 
                                    | BindigFlags.Public)
                          .FirstOrDefault(info => info.Name == "y");
                          
        if (field == null)
        {
           // case when f doesn't have a field
        }
        
        int y = (int)field.GetValue(f);
    }

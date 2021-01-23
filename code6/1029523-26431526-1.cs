    Dictionary<string, FieldInfo> dict = new Dictionary<string, FieldInfo>();
    public bar()
    {
        //If you are using reflection you should be getting this
        FieldInfo info;
        dict[info.Name] = info;
    }
    public foo this[string name]
    {
        get { return dict[name].GetValue(this); }
    }

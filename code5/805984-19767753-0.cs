    [DataMember]
    public List<MyObject> myObjectProp
    {
        get
        {
            return Global.myObject;
        }
     
        set
        {
            Global.myObject = value;
        }   
    }

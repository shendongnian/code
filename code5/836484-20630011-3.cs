    public MyEnum MyEnumProperty { get; set; }
    public string MyEnumText    //New Property
    {
        get
        {
            return MyEnumProperty.GetDescription();
        }
    }

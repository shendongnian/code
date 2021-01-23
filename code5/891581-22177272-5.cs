    [DataMember(Order = 2)]
    public new bool? MyNewProperty
    {
        get { return base.MyNewProperty; }
        set { base.MyNewProperty= value; }
    }

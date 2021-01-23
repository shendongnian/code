    [Serializable]
    class MyClassB
    {
    public string Name{get; set;}
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public MyClassC Property1 {get; private set;}
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BindingList<MyClassC> Test{get; private set;}
    }
    
     [Serializable]
    class MyClassC
    {
    public string Name{get; set;}
    }

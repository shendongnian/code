    private int prop1;
    public int Prop1 {
        get { return prop1; }
        set { SetValue(ref prop1, value); }
    }
    private string prop2;
    public string Prop2 {
        get { return prop2; }
        set { SetValue(ref prop2, value); }
    }
    private bool prop3;
    public bool Prop3 {
        get { return prop3; }
        set { SetValue(ref prop3, value); }
    }
    void SetValue<T>(ref T field, T value) {
        if(!Enabled) {
            throw new InvalidOperationException(
              "The property cannot be changed because the Enabled flag is not set");
        }
        field = value;
    }
    public bool Enabled {get;private set;}

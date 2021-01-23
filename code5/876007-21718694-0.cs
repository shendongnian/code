    public static readonly DependencyProperty MyCustomProperty = 
    DependencyProperty.Register("MyCustom", typeof(string), typeof(SampleUserControl));
    public string MyCustom
    {
        get
        {
            return this.GetValue(MyCustomProperty) as string;
        }
        set
        {
            this.SetValue(MyCustomProperty, value);
        }
    }

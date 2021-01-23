    public MyClass()
    {
        InitializeComponent();
    }
    public void CheckBoxChecked()
    {
        SetBinding(TagProperty, new Binding("Text"){Source=TradeTextBox, Mode=TwoWay});
        Tag="30";
    }

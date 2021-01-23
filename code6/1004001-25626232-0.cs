    public string MyX
    {
        get { return (string)GetValue(MyXProperty); } //Supposing that the property type is string
        set { SetValue(MyXProperty, value); }
    }

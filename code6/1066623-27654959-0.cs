    public string TextBox1Text
    {
        get{return _text1;}
        set{_text1 = value; NotifyPropertyChanged("ComputedProperty")}
    }
    public string TextBox2Text
    {
        get{return _text2;}
        set{_text2 = value; NotifyPropertyChanged("ComputedProperty")}
    }
    public string ComputedProperty
    {
        get {return string.Format("{0:0.00}", double.Parse(TextBox2Text) - double.Parse(TextBox1Text));}
    }

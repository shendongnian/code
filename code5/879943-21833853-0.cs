    //Old ctor
    public Cls()
    {
        PropertyChanged += new PropertyChangedEventHandler(Cls_PropertyChanged); //Register the event handler
        MyProperty = "Hello";
    }
        
    void Cls_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName); //Call your method
    }

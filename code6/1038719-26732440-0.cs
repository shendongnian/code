    MyClass myClass = new MyClass();
    myClass.PropertyChanged += myClass_PropertyChanged;
    ...
    public void myClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyProperty")
            DoWork();
    }
    public void DoWork()
    {
        //Your functionality.
    }

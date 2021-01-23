    void SomeMethod()
    {
        var instance = new GoodClass();
        instance.PropertyChanged += this.OnPropertyChanged;
    }
    void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Value")
        {
            // Do something here.
        }
    }

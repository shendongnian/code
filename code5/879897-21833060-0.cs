    var dataContext = DataContext as MyDataContext;
    dataContext.PropertyChanged += dataContext_PropertyChanged;
    // check for the propertyname and react
    void dataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyProperty")
        {
            // Do things
        }
    }

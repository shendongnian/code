    private void SubPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "DateOfBirth")
        {
           OnPropertyChanged("Age");
        }
    }

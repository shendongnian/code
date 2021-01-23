    private void PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (String.IsNullOrEmpty(e.PropertyName) || e.PropertyName == "IsSelected")
        {
            //pass on the event
        }
    }

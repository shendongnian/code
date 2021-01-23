    private void RaiseAllPropertiesChanged()
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(string.Empty));            
        }
    }

    private void RaiseAllPropertiesChanged()
    {
        var handler = PropertyChangedHandler;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(string.Empty));            
        }
    }

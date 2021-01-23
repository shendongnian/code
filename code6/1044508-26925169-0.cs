    public bool IRCommandSent
    {
        set
        {
            // set the value
            // ...
            // notify event listeneers that the ConnectionWithServerEstablished may have changed
            if (PropertyChanged != null)
            {
                 PropertyChanged(this, new PropertyChangedEventArgs("ConnectionWithServerEstablished"));
            }
        }
    }

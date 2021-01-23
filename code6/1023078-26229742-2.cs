    protected virtual void OnPropertyChanged(string propertyName)
    {
        // other stuff
        // update calculated property
        if (propertyName == "A" || propertyName == "B")
        {
            // this will cause binding target to re-read C value
            OnPropertyChanged("C");
        }
    }

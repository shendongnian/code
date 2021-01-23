    public bool CanSave(object parameter)
    {
        clsProducts instance = (clsProducts)parameter;
        instance.ExternalError = YourCollectionProperty.Contains(instance) ? 
            "The values must be unique" : string.Error;
        // Perform your can save checks here
    }

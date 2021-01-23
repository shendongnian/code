    private void SomeObject_PropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == ExtendedObject.GetPropertyName(_ => _.Property1)
        {
            // ...
        }
    }

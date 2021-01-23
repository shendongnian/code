    private void SomeObject_PropertyChanged(object sender, PropertyChangedEventArgs args)
    {
        object value = 
            sender.GetType().GetProperty(args.PropertyName).GetValue(sender, null);
    }

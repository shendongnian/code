    Y = ((double)(sbyte)value) / 64.0;
    Y = Math.Round(Y, 2);
    SetGetAccValues set = new SetGetAccValues();
    set.PropertyChanged += SetGetAccValuesPropertyChanged;
    set.xValue = Y.ToString();
    private void SetGetAccValuesPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        // Respond to the property changed event here..
    }

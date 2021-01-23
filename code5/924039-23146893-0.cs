    private T SetPropertyValue<T>(ref T property, T value)
    {
        if (!EqualityComparer<T>.Default.Equals(property, value))
        {
            if (!IsInitializing)
            {
                IsDirty = true;
            }
            property = value;
        }
    }
    public DateTimeOffset? ActualProjectCompletionDate
    {
        get { return _actualProjectCompletionDate; }
        set { SetPropertyValue(ref _actualProjectCompletionDate, value); }
    }

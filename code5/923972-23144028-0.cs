    bool UpdateAndRaiseIfNecessary( ref string baseValue, string newValue, [CallerMemberName] string propertyName = null)
    {
        if (baseValue != newValue)
        {
            baseValue = newValue;
            OnPropertyChanged( propertyName );
            return true;
        }
        return false;
    }

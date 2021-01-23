    public bool IsValid ()
    {
        for (string propertyName in allPropertyNames)
        {
            if (!string.IsEmptyOrNull(((IDataErrorInfo)this)[propertyName]))
                return false;
        }
        return true;
    }

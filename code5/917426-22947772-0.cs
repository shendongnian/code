    #region IDataErrorInfo Members
    
    public string Error
    {
        get { return null; }
    }
    
    public string this[string columnName]
    {
        get
        {
            //Your validations here    
            return string.Empty;
        }
    }
    
    #endregion

    #region IDataErrorInfo Members
    
    public string Error
    {
        get { return null; }
    }
    
    public string this[string columnName]
    {
        get
        {
            if (columnName == "YourProperty")
            {
                int property = Convert.ToInt32(YourProperty);
                if (property < 0 || property > 9)
                    return "The value must be between 0 and 9";
            }
    
            return string.Empty;
        }
    }
    
    #endregion

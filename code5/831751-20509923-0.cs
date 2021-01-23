    public class Customer : IDataErrorInfo
    {
        ...
    
        #region IDataErrorInfo Members
    
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
    
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Name))
                        return "Name is Required";
                }
    
                // If there's no error, null gets returned
                return null;
            }
        }
        #endregion
    }

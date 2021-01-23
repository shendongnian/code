    public string this[string columnName]
    {
        get
        {
            string result = null;
            if (columnName == "FirstName")
            {
                if (string.IsNullOrEmpty(FirstName))
                    result = "Please enter a First Name";
            }
            if (columnName == "LastName")
            {
                if (string.IsNullOrEmpty(LastName))
                    result = "Please enter a Last Name";
            }
            return result;
        }
    }

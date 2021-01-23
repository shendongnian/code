    DateTime? budgetDate;
    var ordinal = myDataReader.GetOrdinal("Budget_Date");
    
    var value = myDataReader.GetMySqlDateTime(ordinal);
    
    if(!value.IsValidDateTime && value.IsNull)
    {
        budgetDate = null;
    }
    else if(value.IsValidDateTime)
    {
        budgetDate = value.GetDateTime();
    }
    else
    {
        // Error with data
    }

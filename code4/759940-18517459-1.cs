    DateTime? budgetDate;
    
    var value = myDataReader["Budget_Date"];
    
    if (value == DBNull.Value)
    {
        budgetDate = null;
    }
    DateTime result;
    
    if(!DateTime.TryParse(value.ToString(), out result))
    {
        // Error with data
    }
    budgetDate = result;

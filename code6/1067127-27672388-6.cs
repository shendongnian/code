    private DataTable ResetAutoIncrementColumn(DataTable dt, string autoIncrementColumnName)
    {
        DataTable result = new DataTable();
        DataColumn itemNumber = new DataColumn(autoIncrementColumnName);
        itemNumber.AutoIncrement = true;
        itemNumber.AutoIncrementSeed = 1;
        itemNumber.AutoIncrementStep = 1;
        result.Columns.Add(itemNumber);
    
        dt.Columns.Remove(autoIncrementColumnName);
        result.Merge(dt, true);
        return result;
    }

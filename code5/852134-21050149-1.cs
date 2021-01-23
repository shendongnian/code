    public static bool IsNull(this DataSet dataSet, int rowNumber, string columnName, string errorMsg)
    {
        if(dataSet.Tables[0].Rows[rowNumber].IsNull(columnName))
        {
            // print an error message using Console or MessageBox, or whatever you use
            return true;
        }
        return false;
    }

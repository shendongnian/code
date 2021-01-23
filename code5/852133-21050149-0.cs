    public static class Extensions
    {
        public static bool IsNull(this DataSet dataSet, int rowNumber, string columnName)
        {
            return dataSet.Tables[0].Rows[rowNumber].IsNull(columnName);
        }
    }

    public static class DataColumnExtensions
    {
        // Will work with both the arrays and lists
        public static void SetValues<T>(this DataColumn column, IList<T> values)
        {
            if (column == null)
                throw new ArgumentNullException("column");
            if (values== null)
                throw new ArgumentNullException("values");
    
            DataTable dt = column.Table;             
               
            if (dt.Rows.Count != values.Count)
                 throw new Exception("Lengths are inconsistent");
        
            for (int i = 0; i < values.Count; i++)
            {
                dt.Rows[i][column] = values[i];
            }
        }
    }

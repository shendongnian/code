    public static class DataColumnExtensions
    {
        public static void SetValues<T>(this DataColumn column, T[] values)
        {
            if (column == null)
                throw new ArgumentNullException("column");
            if (values== null)
                throw new ArgumentNullException("values");
    
            DataTable dt = column.Table;             
               
            if (dt.Rows.Count != values.Length)
                 throw new Exception("Lengths are inconsistent");
        
            for (int i = 0; i < destinationFiles.Length; i++)
            {
                dt.Rows[i][column] = destinationFiles[i];
            }
        }
    }

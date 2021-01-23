    [DebuggerStepThrough]
    public static class SqlDataReaderExtensions
    {
        /// <summary>Gets a value that indicates whether the column contains non-existent or missing values.</summary>
        /// <param name="name">The name of the column. </param>
        /// <returns> <see langword="true" /> if the specified column value is equivalent to <see cref="T:System.DBNull" />; otherwise <see langword="false" />.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The name specified is not a valid column name. </exception>
        public static bool IsDBNull(this SqlDataReader reader, string name)
        {
            int columnOrdinal = reader.GetOrdinal(name);
            return reader.IsDBNull(columnOrdinal);
        }
    }
    
    // Usage
    if (read.Read())
    {
        maskedTextBox2.Text = read.IsDBNull("MyColumnName") ? 
                      string.Empty : 
                      read.GetDateTime("MyColumnName").ToString("MM/dd/yyyy");
    
    }

    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    
    public static class SqlDataReaderExtensions
    {
    	public static int GetNthOrdinal(this SqlDataReader reader, string columnName, int nthOccurrence = 1)
    	{
    		// Get the schema which represents the columns in the reader
    		DataTable schema = reader.GetSchemaTable();
    
    		// Find all columns in the schema which match the name we're looking for.
    		// schema is a table and each row is a column from our reader.
    		var occurrences = schema.Rows.Cast<DataRow>().Where(r => string.Equals((string)r["ColumnName"], columnName, StringComparison.Ordinal));
    
    		// Get the nthOccurrence.  Will throw if occurrences is empty.
    		// reader.GetOrdinal will also throw if a column is not present, but you may want to
    		// have this throw a more meaningful exception
    		var occurrence = occurrences.Skip(nthOccurrence - 1).First();
    
    		// return the ordinal
    		return (int)occurrence["ColumnOrdinal"];
    	}
    }

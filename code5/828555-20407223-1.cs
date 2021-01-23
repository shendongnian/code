    table.Rows[0].DbBoolNullable("ColumnName")
    public static bool DbBoolNullable(this DataRow row, string colName)
    {
        return Convert.IsDBNull(row[colName])
            ? false 
            : bool.Parse(row[colName].ToString());
    }

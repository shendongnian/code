    table.DbBoolNullable(0, "ColumnName")
    public static bool DbBoolNullable(this DataTable table, int rowNum, string colName)
    {
        return Convert.IsDBNull(table.Rows[rowNum][colName])
            ? false 
            : bool.Parse(table.Rows[rowNum][colName].ToString());
    }

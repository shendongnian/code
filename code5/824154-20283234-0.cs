    private void SignIn_Time(OleDbCommand updateCmd, OleDbConnection OLEDB_Connection, 
                             Object varName, Object varID, String varTime)
    {
        OLEDB_Connection.Open();
        string varTimeColumn = "TimeIn" + GetUniqueNumber().ToString();
        updateCmd.Connection = OLEDB_Connection;
        updateCmd.CommandText = "ALTER TABLE TestDB ADD COLUMN " + varTimeColumn + " TEXT";
        updateCmd.ExecuteNonQuery();
        updateCmd.CommandText = "INSERT INTO TestDB (varTimeColumn) VALUES (@TIMEIN)";
        updateCmd.Parameters.AddWithValue("@TIMEIN", varTime);
        updateCmd.ExecuteNonQuery();
        OLEDB_Connection.Close();
    }
    static int counter;
    public static int GetUniqueNumber()
    {
        return counter++;
    }

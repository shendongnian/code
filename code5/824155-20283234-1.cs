    private void SignIn_Time(OleDbCommand updateCmd, OleDbConnection OLEDB_Connection, 
                             Object varName, Object varID, String varTime)
    {
        try
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
        catch(Exception ex)
        {
            if(OLEDB_Connection.State == ConnectionState.Open)
                OLEDB_Connection.Close();
            // Perhaps in debug you could do something here with the exception like a log message
            // or rethrow the execption to be handled at an upper level...
            throw;
        }
    }
    static int counter;
    public static int GetUniqueNumber()
    {
        return counter++;
    }

    public static Boolean doQuery(string query, string problem, string maintenanceID, DateTime myDate)
    {
        bool succes = false;
        OracleCommand cmd = new OracleCommand(query, connection);
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
           
            OracleParameter param1 = new OracleParameter();
            param1.OracleDbType = OracleDbType.Nvarchar2;
            param1.ParameterName = "problem";
            param1.Value = problem;
            OracleParameter param2 = new OracleParameter();
            param2.OracleDbType = OracleDbType.Nvarchar2;
            param2.ParameterName = "maintenanceID";
            param2.Value = maintenanceID;
            OracleParameter param3 = new OracleParameter();
            param3.OracleDbType = OracleDbType.Date;
            param3.ParameterName = "myDate";
            param3.Value = myDate;
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();
            succes = true;
        }
        catch (Exception e)
        {
            Debug.WriteLine("[OracleSQL]Error, message: " + e.Message);
        }
        finally
        {
            connection.Close();
            cmd.Dispose();
        }
        return succes;
    }

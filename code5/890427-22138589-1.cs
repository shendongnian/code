        try
        {
        //your code here
        }
        catch(SqlException e){ Console.WriteLine(e.Message); }
        finally
        { if (MySQLConnectrion != null)
            {
                MySQLConnection.Close();
            }
        }

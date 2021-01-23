    private void CreateTablesIfNotExisting()
    {
        string sql =
                    "IF NOT EXISTS ( "
                    + " SELECT * FROM sys.Tables WHERE NAME='Vehicles')"
                    + " CREATE TABLE Vehicles( "
                    + " VIN varchar(20) PRIMARY KEY, "
                    + " Make varchar(20), "
                    + " Model varchar(20), Year int); "
                   + "IF NOT EXISTS ( "
                    + " SELECT * FROM sys.Tables WHERE NAME='Repairs')"
                    + " CREATE TABLE Repairs( "
                    + " ID int IDENTITY PRIMARY KEY, "
                    + " VIN varchar(20), "
                    + " Description varchar(60), "
                    + " Cost money);";
        try
        {
            using(var cn=new SqlConnection(cnString))
            using(var cmd=new SqlCommand(sql,cn))
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

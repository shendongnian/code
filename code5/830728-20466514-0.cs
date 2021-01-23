    public string DBStatus(string Instance, string Asset, string Type)
    {
        DatabaseDetails DbDetails = new DatabaseDetails 
                                   { 
                                       DBStatus = new string[DBStatus + 1]
                                       //initialize DbInstance and AssetName too 
                                   };
    
        using (SqlConnection SqlConn = new SqlConnection())
        {
            try
            {
                //SqlConn.ConnectionString = "Data Source=" + ServerName + "Initial Catalog=" + DBName + "User id=" + UserId + "Password=" + Pwd;
                SqlConn.ConnectionString = "server=" +ServerName+ ";database=" +DBName+ ";UID=" +UserId+ ";PWD="+Pwd ;
                SqlConn.Open();
        
                DbDetails.DBStatus[DBStatus] = "Online";
                DbDetails.DbInstance[DBStatus] = Instance;
                DbDetails.AssetName[DBStatus] = Asset;
                DBStatus++;
                //json = "Online";
            }
            catch (Exception e)
            {
                json = "Offline";
            }
        }
    
    }

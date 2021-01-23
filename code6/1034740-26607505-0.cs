    public void DeleteRow(string ConnectionName)
    {
       string ConnectionString = 
              ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
       SqlConnection con = new SqlConnection(ConnectionString);
       /*
        *  your code goes here.. 
        * 
        */
    }

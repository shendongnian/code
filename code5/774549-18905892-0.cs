    public string getVersion()
    {
        try
        {
            // Use TOP (N) http://technet.microsoft.com/en-us/library/bb686896.aspx
            string dynSQL = "SELECT TOP (1) ID FROM invHeader";
            return (string)(new SqlCeCommand(dynSQL, dbconn.getConnection()).ExecuteScalar());
        }
        catch (Exception ex)
        {
            Platypus.ExceptionHandler(ex, "InvHeader.getVersion");
        }
    } // getVersion   
 

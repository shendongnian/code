     public static SqlCommand CreateCommand(string iProcedureName) {
        try {
           SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
           SqlCommand objCommand = new SqlCommand(iProcedureName,  objConnection);
           // add this line here!!
           objCommand.CommandType = CommandType.StoredProcedure;
           return objCommand;
        }
        catch {
            throw;
        }
     }

    private static void Main(string[] args)
    {
            
        // Build a command text with parameters placeholders (@xxxx)
        string query = @"UPDATE dbo.IMAGE
                        SET PIXEL_HEIGHT = @Height, PIXEL_WIDTH = @Width, 
                            SIZE = @FileSize WHERE IMAGE_NO = @imageNo;";
        // Create a parameter list. Each parameter name should match the parameter 
        // placeholder in the command text and EACH parameter should be defined with
        // the appropriate SqlDbType for the underlying datatable field that will be 
        // updated..
        List<SqlParameter> pList = new List<SqlParameter>();
        pList.Add(new SqlParameter 
        {
           ParameterName = "@Height",
           SqlDbType = SqlDbType.Int,
           Value = Height
        });
        pList.Add(new SqlParameter 
        {
           ParameterName = "@Width",
           SqlDbType = SqlDbType.Int,
           Value = Width
        });
        .... and so on for the other parameter required
        // Now call you RunQuery, but pass also the parameter list
        RunQuery(query, pList);
    }
    // The method receives the command text and the parameters required to run the query
    private static void RunQuery(string cmdText, List<Parameter> pList = null)
    {
         using(SqlConnection cn = new SqlConnection(....constring....))
         using(SqlCommand cmd = new SqlCommand(cmdText, cn))
         {
             cn.Open();
             if(pList != null) cmd.Parameters.AddRange(pList.ToArray());
             cmd.ExecuteNonQuery();
         }
    }

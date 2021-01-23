    ...
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    ....
    
    string oraConnectionString = "Data source=data_source; User id=user_name; password=pwd;";
    OracleConnection oraConnection = new OracleConnection(oraConnectionString);
    oraConnection.Open();
    OracleCommand oraCmd = new OracleCommand("INSERTforum", oraConnection);
    oraCmd.CommandType = System.Data.CommandType.StoredProcedure;
                                                                    /*or Decimal*/
    oraCmd.Parameters.Add(new OracleParameter("p_course_id", OracleDbType.Int32,
                          System.Data.ParameterDirection.Input)).Value = 123;
    oraCmd.Parameters.Add(new OracleParameter("p_question",  OracleDbType.Varchar2,
                          System.Data.ParameterDirection.Input)).Value = "question";
    oraCmd.Parameters.Add(new OracleParameter("p_postername", OracleDbType.Varchar2,
                          System.Data.ParameterDirection.Input)).Value = "postername";
    oraCmd.Parameters.Add(new OracleParameter("p_blog_date", OracleDbType.Date,
                          System.Data.ParameterDirection.Input)).Value = DateTime.Now;
    try 
    {
        oraCmd.ExecuteNonQuery();
     }
     catch (Exception ex)
     {
        Console.WriteLine(ex.Message);
     }

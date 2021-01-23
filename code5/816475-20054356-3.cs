    public  DataTable SelectDataTable(String Sql)
    {
    DataTable dt = new DataTable();
    SqlConnection oSqlConnection = new SqlConnection(GetConnectionStrings());
    
    try
    {
    oSqlConnection.Open();
    SqlDataAdapter sqlda = new SqlDataAdapter(Sql, GetConnectionStrings());
    sqlda.Fill(dt);
    }
    catch (Exception ex)
    {
    throw new Exception(ex.Message);
    }
    finally
    {
    oSqlConnection.Close();
    oSqlConnection.Dispose();
    }
    
    return dt;
    } 
    

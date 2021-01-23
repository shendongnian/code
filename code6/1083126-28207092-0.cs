    try
    {
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString);
        connection.open();
    }
    catch (Exception ex)
    {
        Response.Write(ex.Message);
    }

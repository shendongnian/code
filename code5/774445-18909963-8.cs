    SqlConnection connection = new SqlConnection(ConnectionString);
    command = new SqlCommand("TestProcedure", connection);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    connection.Open();
    DataTable dt = new DataTable();
    dt.Load(command.ExecuteReader());
    gvGrid.DataSource = dt;
    gvGrid.DataBind();

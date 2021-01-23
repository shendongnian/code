    DataTable data = new DataTable();
    using (var connection = new SqlConnection(connString))
    using (var command = new SqlCommand(queryStringParent, connection))
    using(var da = new SqlDataAdapter(command))
    {
        // you don't need to open/close the connection with Fill
        da.Fill(data);
    }
    gvParentTasks.DataSource = data;
    gvParentTasks.DataBind();

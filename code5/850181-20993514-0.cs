    // Create SQLDataSource.
    SqlDataSource sqlDataSource = new SqlDataSource();
    sqlDataSource.ID = "SqlDataSource123";
    
    //Bind SQLDataSource to GridView
        GridView1.DataSource = sqlDataSource;
        GridView1.DataBind();

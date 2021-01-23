    using(OleDbConnection con = new OleDbConnection(connection))
    using(var adapter = new OleDbDataAdapter("select * from registration", con)
    {
      DataSet ds =new DataSet();
      adapter.Fill(ds);
      GridView1.DataSource = ds;
      GridView1.DataBind();
    }
            

    SqlConnection con = new SqlConnection("Data Source=DShp;Initial Catalog=abc;Integrated Security=True");
    SqlDataAdapter da = new SqlDataAdapter("data", con);
    da.SelectCommand.CommandType= CommandType.StoredProcedure;
    DataSet ds=new DataSet();
    da.Fill(ds, "data");
    GridView1.DataSource = ds.Tables["data"];
    GridView1.DataBind();

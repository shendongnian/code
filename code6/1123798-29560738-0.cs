    String str = "select * from Stock where (ItemName like '%' + @search + '%')";// saving my query as a string variable
    SqlCommand xp = new SqlCommand(str, conn);
    xp.Parameters.Add("@search", SqlDbType.VarChar).Value = txtSearch.Text;
    //opening my connection 
    con.Open();
    
    //Excuting my command which i saved as a string 
    xp.ExecuteNonQuery();
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = xp;
    
    DataSet ds = new DataSet();
    //Has to be the same name a in the DB
    da.Fill(ds, "ItemName");
    
    GridView1.DataSource = ds;
    GridView1.DataBind();
    
           
    conn.Close();

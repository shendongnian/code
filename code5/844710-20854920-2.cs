     protected void Button1_Click1(object sender, EventArgs e)
     {
       
       SqlConnectionStringBuilder connb = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SCS"].ConnectionString);
       using (SqlConnection conn = new SqlConnection(connb.ConnectionString))
       {
        try
        {
          SqlCommand cmd = new SqlCommand("Select * from dbo.Users;", conn);
          DataTable tb = new DataTable();
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(tb);
          tb.AcceptChanges();
          GridView1.DataSource = tb;
          GridView1.DataBind();
          GridView1.Rows[0].Cells[0].Text. = "a";
        }
        catch(Exception ex)
        {
             Response.Write(ex.Message);
        }     
       }           
    }

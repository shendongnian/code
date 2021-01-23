    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RBConnectionString"].ConnectionString))
       {
          SqlCommand cmd = new SqlCommand("select * from Customers", con);
          cmd.CommandType = CommandType.StoredProcedure;
          SqlDataAdapter adpt = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          adpt.Fill(dt);
          repeaterObj.DataSource = dt;
          repeaterObj.DataBind();
          cmd.Dispose();
        }
     }

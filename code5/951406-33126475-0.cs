    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       using (SqlConnection con = new SqlConnection(Connection_String))
       {
          SqlCommand cmd = new SqlCommand("Your_Database_Query", con);
          cmd.CommandType = CommandType.StoredProcedure;
          SqlDataAdapter adpt = new SqlDataAdapter(cmd);
          DataTable dt = new DataTable();
          adpt.Fill(dt);
          repeaterObj.DataSource = dt;
          repeaterObj.DataBind();
          cmd.Dispose();
        }
     }

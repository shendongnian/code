     protected void TextBox1_TextChanged1(object sender, EventArgs e)
     {
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
       con.Open();
       SqlCommand cmd=new SqlCommand("select name from tbl_data_show",con);
       DataTable dt=new DataTable();
       SqlDataAdapter da=new SqlDataAdapter(cmd);
       da.Fill(dt);
       SqlDataReader dr=cmd.ExecuteReader();
       While(dr.Read())
       {
        if(dt.Rows.count>0)
        {
          if (TextBox1.Text == dr.GetString(0))
            {
                Label1.Text = "4";
                Label1.Visible = true;
            }
            else if (TextBox1.Text != dr.GetString(0))
            {
                Label2.Text = "5";
                Label2.Visible = true;
            }
        }
      }  
      con.Close();
    }

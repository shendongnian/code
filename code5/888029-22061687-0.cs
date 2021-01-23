    SqlCommand cmd=new SqlCommand("DELETE  from [course] where cid IN ('"+cids.Text+"')",con);
----------
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd=new SqlCommand("DELETE  from [course] where cid IN ('"+cids.Text+"')",con);
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("done.aspx");
                con.Close();
            }
            catch (SqlException ex)
            { 
             Label1.Text = "error";
            }
        }
             

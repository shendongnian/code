         SqlConnection con;    
        protected void Page_Load(object sender, EventArgs e)
                {
        try
        {            
        con = new SqlConnection("Data Source=MJ-PC;Initial Catalog=Test;Integrated Security=True");
                    con.Open();
        }
        catch
        {
        //Handles exceptions here
        }
                }
            
                protected void btnsubmit_Click(object sender, EventArgs e)
                {
                  try
                  {
                    //SqlCommand cmd = con.CreateCommand();
                    SqlCommand cmd = new SqlCommand("select password from TestDemo where userName='" + txtusername .Text+ "'", con);
            
                    //cmd.Connection = con;
            
                    SqlDataReader da;
                    da = cmd.ExecuteReader();
                    if (!da.Read())
                    {
                        Response.Write("Wrong Details");
                    }
                    else
                    {
                        if(da[0].ToString()==txtusername.Text)
                             Response.Redirect("WebForm1.aspx");
                        else
                            Response.Write("Wrong Password");
                    }
                  }
                  finally
                  {
                  con.Close();
                  }
                }

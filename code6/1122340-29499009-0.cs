    protected void Button1_Click(object sender, EventArgs e)
    {
            Session["BID"] = B_id.Text;
            SqlConnection conne = new SqlConnection(ConfigurationManager.ConnectionStrings["D"].ConnectionString);
            String checkuser = "select * from Students where Id=@ppid";
            SqlCommand com = new SqlCommand(checkuser, conne);
            com.Parameters.AddWithValue("@ppid", B_id.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var pid = Session["BID"];
            if (dt.Rows.Count > 0)
            {
                SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString);
                SqlCommand cmd1 = new SqlCommand("select * from Students where Id=@pid", conn1);
                cmd1.Parameters.AddWithValue("@pid", pid);//Missing in your code
                conn1.Open();
                if (cmd1.ExecuteNonQuery().ToString() != null)
                {
                    Response.Redirect("H2.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('not registered')</script>");
                }
                conn1.Close();
            }
            SqlConnection conne1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString);
            String checkuser2 = "select * from Students where ID=@ppid";
            SqlCommand com1 = new SqlCommand(checkuser2, conne);
            com1.Parameters.AddWithValue("@ppid", B_id.Text);
            SqlDataAdapter da1 = new SqlDataAdapter(com1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                SqlConnection conn11 = new SqlConnection(ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString);
                SqlCommand cmd2 = new SqlCommand("select * from Students where PID=@pid", conn11);
                conn11.Open();
                if (pid != cmd2)
                {
                    Response.Redirect("HReg.aspx");
                }
                conn11.Close();
            }
        }

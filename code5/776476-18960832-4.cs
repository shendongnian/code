    protected void GridviewBind ()
    {
        using (SqlConnection con = new SqlConnection("Data Source=RapidProgramming;Integrated Security=true;Initial Catalog=RPDB"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Name,Salary FROM YOUR TABLE", con);
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            con.Close();
        }
    }

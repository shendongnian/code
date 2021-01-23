    con.Open();
    string query = "select Calf_ID,Plant,date1,Event from Holiday_Master ";
    cmd = new SqlCommand(query, con);
    cmd.CommandType = CommandType.Text;
    using (SqlDataReader dr = cmd.ExecuteReader())
    {
       GridView1.DataSource = dr;
       GridView1.DataBind();
    }
    
    con.Close();

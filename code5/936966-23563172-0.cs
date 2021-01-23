    SqlConnection con = new SqlConnection("Your Connection String");
    con.Open();
    SqlCommand cmd = new SqlCommand("Select Max(CallID) from Yourtablename",con);    
    SQlDataReader dr = cmd.ExecuteReader();
    while(dr.Read())
    {
        Label1.Text = dr.GetInt32(0).ToString();
    }
    con.Close();

    SqlCommand myCommand = new SqlCommand(readsql, myConnection);
    myCommand.Parameters.AddWithValue("@username", username1);
--------------------------------------
    protected void Page_Load(object sender, EventArgs e)
        {
           string username1 = User.Identity.Name;
           
            string readsql = "SELECT title, gname, sname, dob, address, suburb, postcode, dayphone, email FROM users WHERE username = @username";
            using (SqlConnection myConnection = new SqlConnection(strConnString))
            {    
                myConnection.Open();    
                SqlCommand myCommand = new SqlCommand(readsql, myConnection);
                myCommand.Parameters.AddWithValue("@username", username1);
                SqlDataReader reader = myCommand.ExecuteReader();
                myCommand.ExecuteNonQuery();
                reader.Read();
                Label2.Text = reader["title"].ToString();
                Label3.Text = reader["gname"].ToString();
                Label4.Text = reader["sname"].ToString();
                Label5.Text = reader.GetDateTime(reader.GetOrdinal("dob")).ToString();
                Label6.Text = reader["address"].ToString();
                Label7.Text = reader["suburb"].ToString();
                Label18.Text = reader["postcode"].ToString();
                Label8.Text = reader["dayphone"].ToString();
                Label9.Text = reader["email"].ToString();
                reader.Close();
                myConnection.Close();
            }

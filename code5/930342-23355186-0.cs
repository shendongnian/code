    using (SqlConnection con = new SqlConnection (connectionstring))
    {
     SqlCommand cmd1 = new SqlCommand("select UserId from Users where username=@username and password=@password",con);
     con.Open();
     int UID = (int)cmd1.ExecuteScalar(); //Execute command and assign value
     Session["ID"] = UID; //Now set session variable
    }

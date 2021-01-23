    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AddUser()
    {
        /// here you get your json object from post data
        var serializedUser = Request.Form["user"] as string;
        var user = JsonConvert.DeserializeObject<User>(serializedUser);
        SqlConnection con = new SqlConnection(@"Data Source=172.16.176.74;Initial Catalog=test001;Persist Security Info=True;User ID=onbapps;Password=sdu_123456");
        SqlCommand cmd = new SqlCommand("insert into [dbo].[User] values(@fname,@lname,@mi)", con);
        
        con.Open();
        cmd.Parameters.AddWithValue("@fname", user.FirstName);
        cmd.Parameters.AddWithValue("@lname", user.LastName);
        cmd.Parameters.AddWithValue("@mi", user.Mi);
        cmd.ExecuteNonQuery();
        con.Close();
    }

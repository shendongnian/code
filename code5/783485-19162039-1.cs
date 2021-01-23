    public static int checkuser(string myuser, string mypass)
    {
        string passHash = BCrypt(mypass); //Need to get bcyrpt library and make the function
        using (MySqlConnection conn = new MySqlConnection(PublicVariables.cs))
        using (MySqlCommand cmd =
                     new MySqlCommand("SELECT username, password, userdegre " + "FROM Users WHERE username = @user" ,conn))
        {
            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 20).Value = myuser;
            conn.Open();
                
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read()) return 2;
                if (Convert.ToString(reader["password"]) != MypassMd5) return -1;
                PublicVariables.UserId = Convert.ToString(reader["username"]);
                PublicVariables.UserDegre = Convert.ToInt16(reader["userdegre"]);
                return 1;
            }
        }
    }

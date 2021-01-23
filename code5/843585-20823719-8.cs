    public class UserRepository
    {
        // NOTE: Use <connectionStrings> section in App.config to store connection string
        private string connectionString = "Data Source=PEWPEWDIEPIE\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        public User GetUser(string userName, string password)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"SELECT ISNULL(SCSID, '') AS SCSID, 
                                           ISNULL(SCSPass,'') AS SCSPass, 
                                           ISNULL(isAdmin,'') AS isAdmin 
                                    FROM SCSID 
                                    WHERE SCSID = @userName ANDnd SCSPass = @password";
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                    return null;
                User user = new User();
                user.Name = userName;
                user.IsAdmin = reader["isAdmin"].ToString() == "yes";
                return user;
            }
        }
    }

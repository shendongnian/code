    class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public User(string userName, string plainTextPassword)
        {
            this.UserName = userName;
            this.Password = GetHash(plainTextPassword);
        }
        public string GetHash(string toHash)
        {
            return BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(toHash))).Replace("-", string.Empty);
        }
        public void Save() { /* Save UserName and the Hashed Password to database */ }
        public bool ValidateLogin(string userNameEntered, string passwordEntered)
        {
            string userName; string password = string.Empty;
            string ConnectionString = "Your Connection String";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string CommandText = "SELECT UserName, Password FROM userLogin WHERE Username = @UserName";
                using (SqlCommand cmd = new SqlCommand(CommandText))
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20).Value = userNameEntered;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        userName = rdr["UserName"].ToString();
                        password = rdr["Password"].ToString();
                    }
                }
            }
            if (password.Equals(GetHash(passwordEntered))) return true;
            return false;
        }
    }

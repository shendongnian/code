    public class DataLayer
    {
        string ConnectionString {get; set;}
        public DataLayer(string connectionString)
        {
           ConnectionString = connectionString;  
        }
        public void UpdateUser(SystemUser user)
        {
            var command = new SqlCommand("UPDATE Users SET first_name = @firstname WHERE ID = @id");
            command.Parameters.AddWithValue("id", user.Id);
            command.Parameters.AddWithValue("firstname", user.FirstName);
            using (var connection = new SqlConnection(ConnectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ChangePassword(string UserId, string password)
        {
            //hash and change password here
        }
    }

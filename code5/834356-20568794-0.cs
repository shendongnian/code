	public class User
    	{
		public long nUser { get; set; }
		public string cUserID { get; set; }
		public string cName { get; set; }
	
		public string cPassword { get; set; }
	}
    public List<User> GetUsers()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                command = new SqlCommand(connection);
                command.CommandType = CommandType.Text;
                List<User> tuserList = new List<User>();
                User tuser = null;
                connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tuser = new User();
                    tuser.nUser = long.Parse(reader["nUser"].ToString());
                    tuser.cUserID = reader["cUserID"].ToString();
                    tuser.cName = reader["cName"].ToString();
                    tuser.cPassword = reader["cPassword"].ToString();
                    tuserList.Add(tuser);
                }
				
                return tuserList;
                
            }
            catch (SqlException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
		

    public void addUsersToList()
    {
        using (SqlConnection sourceConnection =
                       new SqlConnection(connectionString))
            {
                sourceConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT * FROM " +
                    "dbo.Users;",
                    sourceConnection);
                myReader = myCommand.ExecuteReader();
                //long countStart = System.Convert.ToInt32(myCommand.ExecuteScalar());
                List<Users> myList = new List<Users>();
                while (myReader.Read())
                {
                    myList.Add(new Users { Time = myReader["Id"].ToString(), 
                                Acceleration = myReader["Name"].ToString() });
                } 
            }
    }
 
    

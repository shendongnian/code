    using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Employees SET firstname=@firstname, lastname=@lastname" +
                        " WHERE Id=@Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id",user.UserId );
                    cmd.Parameters.AddWithValue("@firstname",user.FirstName);
                    cmd.Parameters.AddWithValue("@lastname",user.LastName);
                    //add whatever parameters you required to update here
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
        }

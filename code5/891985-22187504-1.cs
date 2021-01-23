    private static void Create(string name, string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conn_string))
                {
                    SqlCommand cmd = conn.CreateCommand();
    
                    cmd.CommandText = @"INSERT INTO dbo.Person (name, email)
                                        VALUES (@name, @email)";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                //print custom error message
            }
        }

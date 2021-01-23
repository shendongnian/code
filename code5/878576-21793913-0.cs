       bool IsIdExist(int id)
        {
            using(SqlConnection con = new SqlConnection("Connection String Here"))
            using (SqlCommand command = new SqlCommand("select count(*) from customer where id=@id", con))
            {
                command.Parameters.AddWithValue("@id", id);
                con.Open();
                int rows = Convert.ToInt32(command.ExecuteScalar());
                if (rows > 0)
                    return true;
                return false;
            }            
        }

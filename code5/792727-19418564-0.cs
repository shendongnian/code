    using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=temp;User ID=sa"))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'piv';";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string x = reader.GetString(0);
                    }
                }
            }

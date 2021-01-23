            using (SqlConnection conn = new SqlConnection(builder.ToString()))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        Console.WriteLine(error.Number);
                    }
                }
                catch (Exception ex)
                {
                }
            }

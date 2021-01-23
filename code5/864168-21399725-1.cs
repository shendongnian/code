                try
                {
                    SqlConnection Connection = new SqlConnection(DBC.Constructor);
                    string Sql = " Update Details Set Details = @StudentName1 , SudentAge1 = SudentAge1                            
                    Where StudentID1 = @StudentID1";
                    SqlCommand cmd = new SqlCommand(Sql, Connection);
                    cmd.Parameters.AddWithValue("StudentID1", StudentID); 
                    cmd.Parameters.AddWithValue("StudentName1", StudentName);
                    cmd.Parameters.AddWithValue("SudentAge1", SudentAge);
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

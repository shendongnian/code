                using (var con = new SqlConnection("XX"))
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandText = //properly parameterized query...
                    con.Open();
                    command.ExecuteNonQuery();                
                }//using will automatically correctly close and dipose of the connection when con goes out of scope.

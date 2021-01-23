    static void Main(string[] args)
            {
                string connString = @"here connection string";
                SqlConnection con = new SqlConnection(connString);
                SqlCommand command = con.CreateCommand();
    
                command.CommandText = "Select * from Object";
                con.Open();
                SqlDataReader queryReader = command.ExecuteReader();
                StreamWriter file = new StreamWriter(@"C:\Projects\EverydayProject\test.txt");
                while (queryReader.Read())
                {
                    
                    file.WriteLine(queryReader["Title"].ToString() + " " + queryReader["City"].ToString());                      
                }
    
                queryReader.Close();
                con.Close();
                file.Close();
            }

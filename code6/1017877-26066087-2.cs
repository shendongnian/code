            static void Main(string[] args)
            {
                string connString = @"here connection string";
                SqlConnection con = new SqlConnection(connString);
                SqlCommand command = con.CreateCommand();
    
                command.CommandText = "Select * from Object";
                con.Open();
                SqlDataReader queryReader = command.ExecuteReader();
                StreamWriter file = new StreamWriter(@"C:\Projects\EverydayProject\test.txt");
                bool addColumns = false;
                string columnName1="Title";
                string columnName2 = "City"; 
                while (queryReader.Read())
                {
                    if(addColumns)
                    {
                         file.WriteLine(columnName1 + " " + columnName2);
                         addColumns = true;
                    }
                    else
                    {
                         file.WriteLine(queryReader["Title"].ToString() + " " + queryReader["City"].ToString());
                    }                      
                }
    
                queryReader.Close();
                con.Close();
                file.Close();
            }

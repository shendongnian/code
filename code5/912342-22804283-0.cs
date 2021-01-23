    static void Main(string[] args)
    {
        SqlConnection myConnection = new SqlConnection("Server=HABCHY-PC/SQLEXPRESS;" +
                                    "Trusted_Connection=yes;" +
                                    "Database=mydatabase;" +
                                    "User Instance=true;"+
                                    "Connection timeout=30");
        SqlCommand myCommand = new SqlCommand("INSERT INTO students (firstname, age) "+
                                              "Values ('string', 1)", myConnection);
            
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.CommandText = "select * from students";
            SqlDataReader myReader = myReader = myCommand.ExecuteReader();
            
            while (myReader.Read())
            {
                Console.WriteLine(myReader["firstname"].ToString());
                Console.WriteLine(myReader["age"].ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        finally
        {
            myReader.Close();
            myConnection.Close();
        }
    }

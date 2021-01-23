    public int Insert(Program program)
        {
          int resutl;
            SqlConnection Connection = new SqlConnection(DBC.Constructor);
            string Sql = "insert into Details (program.StudentID,program.StudentName,program.SudentAge) Values (@StudentID1,@StudentName1,@SudentAge1)";
            SqlCommand Command = new SqlCommand(Sql, Connection);
            Command.Parameters.AddWithValue("@StudentID1", program.StudentID);
            Command.Parameters.AddWithValue("@StudentName1", program.StudentName);
            Command.Parameters.AddWithValue("@StudentAge1", program.SudentAge);
    
    
            try
            {
                Connection.Open();
             resutl=   Command.ExecuteNonQuery();
    
                try
                {
                    Console.WriteLine("Execute success");
                }
    
                catch
                {
                    Console.WriteLine("Execute is not success");
                }
            Return resutl;
            }
            catch
            {
                Console.WriteLine("Error saving Student");
            }
            finally
            {
                try
                {
    
                    Connection.Close();
                }
                catch
                {
                }
            }

    using(var connection = new SqlConnection(connectionString))
    using(var command = connection.CreateCommand())
    {
        command.CommandText = 
           @"INSERT INTO SchoolDb_Student(StudentName,RollNo,Session,MobileNo)
             VALUES (@studentName, @rollNo, @session, @mobileNo)";
    
        command.Parameters.AddWithValue("studentName", TextBox1.Text);
        command.Parameters.AddWithValue("rollNo", TextBox2.Text);
        command.Parameters.AddWithValue("session", TextBox3.Text);
        command.Parameters.AddWithValue("mobileNo", TextBox4.Text);
    
        connection.Open();
    
        try
        {
            command.ExecuteNonQuery();
        }
        catch(SqlException e)
        {
            if (e.Message.Contains("Violation of UNIQUE KEY constraint"))
                // you got unique key violation
        }
    }

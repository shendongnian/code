    using (var connection = new OleDbConnection("YouConnectionString"))
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            // Not that all parameters are create with an @ at the front of the name
            command.CommandText = @"INSERT INTO Registration(Name, Branch, College, Contact)
                                    VALUES (@THE_NAME, @THE_BRANCH, @THE_COLLEGE, @THE_CONTACT);";
            // Insert your parameters
            command.Parameters.Add("@THE_NAME", OleDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@THE_BRANCH", OleDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@THE_COLLEGE", OleDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@THE_CONTACT", OleDbType.VarChar).Value = textBox4.Text;
            var i = command.ExecuteNonQuery();
            if(i <= 0)
            {
                throw new Exception("Unable to create record.");
            }
        }
    }

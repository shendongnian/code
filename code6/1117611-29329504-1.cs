    Random rnd = new Random();
    int number = rnd.Next(1000, 5000);
    
    string cmdText = @"UPDATE Registration 
                       SET [Authentication] = @number) 
                       WHERE [Email] = @email";
    using(OleDbConnection connection = new OleDbConnection(....connectionstring ....))
    using(OleDbCommand command = new OleDbCommand(cmdText, connection))
    {
        connection.Open();
        command.Parameters.Add("@number", OleDbType.Integer).Value = number;
        command.Parameters.Add("@email", OleDbType.VarWChar).Value = TextBox1.Text;
        int rowsUpdated = command.ExecuteNonQuery();
        if(rowsUpdated > 0)
            MessageBox.Show("sucessfull");
        else        
            MessageBox.Show("email not found");
    }

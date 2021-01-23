    command.CommandType = CommandType.Text;
    command.CommandText = ("SELECT Total_Bill FROM Computation WHERE Transaction_ID = @ID");
    command.Parameters.AddWithValue("@ID", textBox1.Text);    
    command.Connection = connection;
    try
    {    
      connection.Open();  
      textBox2.Text = (String.Format("{0000,0:N2}", command.ExecuteScalar()));            
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }                 
    connection.Close();
    

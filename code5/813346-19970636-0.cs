    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch(Exception ex)
    {
        MessageBox.Show("Error:" + ex.Message); // This will display all the error in your statement.
    }

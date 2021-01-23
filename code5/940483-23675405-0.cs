    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch (Exception e)
    {
        // Handle excepetion, show message to user...
        MessageBox.Show(e.Message);
    }

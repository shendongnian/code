    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch(SqlException ex) // This will catch all SQL exceptions
    {
        MessageBox.Show("Execute exception issue: "+ex.Message);
    }
    catch(InvalidOperationException ex) // This will catch SqlConnection Exception
    {
        MessageBox.Show("Connection Exception issue: "+ex.Message);
    }
    catch(Exception ex) // This will catch every Exception
    {
        MessageBox.Show("Exception Message: "+ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
    }
    finally // don't forget to close your connection when exception occurs.
    {
    connection.Close();
    }

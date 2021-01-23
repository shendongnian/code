    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch(SqlException ex) // This will catch all SQL exceptions
    {
        MessageBox.Show("Execute exception issue: "+ex);
    }
    catch(InvalidOperationException ex) // This will catch SqlConnection Exception
    {
        MessageBox.Show("Connection Exception issue: "+ex);
    }
    catch(Exception ex) // This will catch every Exception
    {
        MessageBox.Show("Exception Message: "+ex); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
    }

    try
    {
        connection.Open();
        command.ExecuteNonQuery();
    }
    catch(SqlException ex) // This will catch all SQL exceptions
    {
        MessageBox.Show("Execute issue");
    }
    catch(InvalidOperationException ex) // This will catch SqlConnection Exception
    {
        MessageBox.Show("Connection issue ");
    }
    catch(Exception ex) // This will catch every Exception
    {
        MessageBox.Show("General exception"+ex); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
    }

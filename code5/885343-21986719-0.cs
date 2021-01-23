    try
    {
    oleDBConn.Open();
    
    int result = cmd.ExecuteNonQuery();
    
    if (result > 0)
    MessageBox.Show("Success!");
    else
    MessageBox.Show("Sorry!");
    }
    catch (OleDbException)
    {
    MessageBox.Show("There is a problem!");
    }
    finally
    {
    oleDBConn.Close();
    }

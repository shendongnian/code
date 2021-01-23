    try
    {
    oleDBConn.Open();
    
    int result = cmd.ExecuteNonQuery();
    
    if (result > 0)
    MessageBox.Show("Success!");
    else
    MessageBox.Show("Sorry!");
    }
    catch (OleDbException ex)
    {
    MessageBox.Show("There is a problem!"+ex.ToString());
    }
    finally
    {
    oleDBConn.Close();
    }

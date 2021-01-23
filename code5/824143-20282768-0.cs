    try
    {
        conDatabase.Open();
        int numberOfRowsUpdated = cmdDatabase.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    finnaly
    {
        conDatabase.Close();
    }

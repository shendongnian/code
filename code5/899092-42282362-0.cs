    try
    {
        using (OdbcConnection conn = new OdbcConnection(builder.ConnectionString))
        {
            //           
            MessageBox.Show("SUCCEEDED");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"{ResourceManager.GetString("FAILED: ")} {ex.Message}");
    }

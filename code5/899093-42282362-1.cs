    OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder
    builder.Driver = "{SomeDriver}"
    builder.Add("UID", "user");
    builder.Add("PWD", "abc;}45"); 
    MessageBox.Show(builder.ConnectionString) // observe PWD's escaped value of "{abc;}}45}"
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

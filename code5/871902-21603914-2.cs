    List<string> dspString = new List<string>();
    ...
    while(RDisplay.Read())
    {
        try
        {
            dspString.Add(RDisplay.GetString(0));
        }
        catch(OdbcException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

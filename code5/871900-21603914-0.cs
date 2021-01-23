    List<string> doh = new List<string>();
    while(RDisplay.Read())
    {
        try
        {
            doh.Add(RDisplay.GetString(0));
        }
        catch(OdbcException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

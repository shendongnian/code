    try
    {
        bool enabled = ((DataTable)gttBindingSourceLosplaatsen.DataSource).Rows.Count > 0;
        buttonEditLosplaats.Enabled = enabled;
        buttonDeleteLosplaats.Enabled = enabled;
    }
    catch (Exception ex)
    {
        MessageBox.Show("what is this ?");
    }

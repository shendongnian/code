    foreach (DataRow row in ADataTable)
    {
        ComboBox box = new ComboBox();
        box.OnSelectionChanged += comboBox_OnSelectionChanged;
    }
    
    protected void comboBox_OnSelectionChanged(Object sender, EventArgs e)
    {
        if (sender is ComboBox)
        {
            ComboBox box = (ComboBox)sender;
            //do what you like with it
        }
    }

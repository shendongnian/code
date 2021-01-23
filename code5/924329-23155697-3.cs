    private void dataGridView1_EditingControlShowing(
        object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        ComboBox cb = e.Control as ComboBox;
        if (cb != null)
        {
            cb.IntegralHeight = false;
            cb.MaxDropDownItems = 10;
        }
    }

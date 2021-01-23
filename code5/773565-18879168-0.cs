    private void optStatusClosed_CheckedChanged(object sender, EventArgs e)
    {
        if((sender as RadioButton).IsChecked)
        {
           statusChanged();
        }
    }

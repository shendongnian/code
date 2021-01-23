    private void autoCompleteTestBox_TextChanged(object sender, EventArgs e)
    {
        if(CurrentAutoCompleteSelection.Contains(autoCompleteTestBox.Text))
        {
            UpdateAutoCompleteSource();
        }
    }

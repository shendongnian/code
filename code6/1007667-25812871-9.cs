    private void autoCompleteTestBox_TextChanged(object sender, EventArgs e)
    {
        if(CurrentAutoCompleteSelection.Count == 0)
        {
            UpdateAutoCompleteSource();
            return;
        }
        if (CurrentAutoCompleteSelection.Contains(autoCompleteTestBox.Text))
        {
            UpdateAutoCompleteSource();
            return;
        }
        string[] textItems = autoCompleteTestBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        string[] checkItems = CurrentAutoCompleteSelection[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (textItems.Length < checkItems.Length - 1)
        {
            UpdateAutoCompleteSource();
            return;
        }
        for (int i = 0; i < checkItems.Length - 1; i++)
        {
            if (textItems[i].Trim() != checkItems[i].Trim())
            {
                UpdateAutoCompleteSource();
                return;
            }
        }
    }

    private void UpdateAutoCompleteSource()
    {
        string[] textItems = autoCompleteTestBox.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> preSelectedItems = new List<string>();
        foreach (string item in textItems)
        {
            if (FullAutoCompleteSelection.Contains(item.Trim())) { preSelectedItems.Add(item.Trim()); }
        }
        List<string> autoCompleteList = FullAutoCompleteSelection.ToList();
        StringBuilder preString = new StringBuilder();
        foreach (string selectedItem in preSelectedItems)
        {
            if (autoCompleteList.Contains(selectedItem)) { autoCompleteList.Remove(selectedItem); }
            preString.Append(selectedItem + ", ");
        }
        CurrentAutoCompleteSelection = new AutoCompleteStringCollection();
        foreach (string item in autoCompleteList)
        {
            CurrentAutoCompleteSelection.Add(preString + item);
        }
        autoCompleteTestBox.AutoCompleteCustomSource = CurrentAutoCompleteSelection;
    }

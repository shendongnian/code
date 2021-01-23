    private void UpdateAutoCompleteSource()
    {
        List<string> autoCompleteList = FullAutoCompleteSelection.ToList();
        string[] preSelectedItems = autoCompleteTestBox.Text.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder preString = new StringBuilder();
        foreach (string selectedItem in preSelectedItems)
        {
            string trimedItem = selectedItem.Trim();
            if (autoCompleteList.Contains(trimedItem)) { autoCompleteList.Remove(trimedItem); }
            preString.Append(trimedItem + ", ");
        }
        CurrentAutoCompleteSelection = new AutoCompleteStringCollection();
        foreach (string item in autoCompleteList)
        {
            CurrentAutoCompleteSelection.Add(preString + item);
        }
        autoCompleteTestBox.AutoCompleteCustomSource = CurrentAutoCompleteSelection;
    }

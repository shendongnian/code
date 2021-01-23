    private void PopulateListBox(ListBox ListBoxName, Type EnumType)
    {
        foreach (var value in Enum.GetValues(EnumType))
        {
            ListBoxName.Items.Add(value);
        }
        ListBoxName.SelectedIndex=0;
    }

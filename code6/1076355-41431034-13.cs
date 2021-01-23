    private void Pasting_EnhanceComboSearch(object sender, DataObjectPastingEventArgs e)
    {
        ComboBox cmb = (ComboBox)sender;
        cmb.IsDropDownOpen = true;
        string pastedText = (string)e.DataObject.GetData(typeof(string));
        string fullText = cmb.Text.Insert(GetChildOfType<TextBox>(cmb).CaretIndex, pastedText);
        if (!string.IsNullOrEmpty(fullText))
        {
            cmb.ItemsSource = Names.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        }
        else
        {
            cmb.ItemsSource = Names;
        }
    }

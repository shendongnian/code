    private void PreviewTextInput_EnhanceComboSearch(object sender, TextCompositionEventArgs e)
    {
        ComboBox cmb = (ComboBox)sender;
        cmb.IsDropDownOpen = true;
        if (!string.IsNullOrEmpty(cmb.Text))
        {
            string fullText = cmb.Text.Insert(GetChildOfType<TextBox>(cmb).CaretIndex, e.Text);
            cmb.ItemsSource = Names.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        }
        else if (!string.IsNullOrEmpty(e.Text))
        {
            cmb.ItemsSource = Names.Where(s => s.IndexOf(e.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        }
        else
        {
            cmb.ItemsSource = Names;
        }
    }

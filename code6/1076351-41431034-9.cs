    private void PreviewKeyUp_EnhanceComboSearch(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Back || e.Key == Key.Delete)
        {
            ComboBox cmb = (ComboBox)sender;
            cmb.IsDropDownOpen = true;
            Debug.WriteLine($" # cmb.Text po usunięciu: {cmb.Text}");
            if (!string.IsNullOrEmpty(cmb.Text))
            {
                cmb.ItemsSource = Names.Where(s => s.IndexOf(cmb.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else
            {
                cmb.ItemsSource = Names;//DropdownNames
            }
        }
    }

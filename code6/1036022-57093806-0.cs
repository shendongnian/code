    private void cmbt1Name1_LostFocus(object sender, RoutedEventArgs e)
    {
            ComboBox cmb = sender as ComboBox;
            FillFivePoints(cmb);
    }
    private void FillFivePoints(ComboBox usedCombobox)
    {
        if (txtSerial.AutoCompleteCustomSource.Contains(t.Text))
        {
        ...

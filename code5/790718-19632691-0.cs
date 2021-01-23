    private void ComboBoxSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine(@"selectHandler");
        var cboBox = sender as ComboBox;
        if (cboBox == null)
            return;
    
        if (cboBox.IsDropDownOpen) // a selection in combobox was made
        {
            cboBox.Text = cboBox.SelectedValue as string;
            cboBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
        }
        else // user wants to open the combobox
            cboBox.IsDropDownOpen = true;
    }

    private void deleteItem(ComboBox comboBox, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            if (comboBox.Items.Count == 1)
            {
                comboBox.Items.Clear();
                return;
            }
            comboBox.Items.Remove(comboBox.SelectedItem);
            e.Handled = true; // I do not think this really contributes anything in this case.
        }
    }    

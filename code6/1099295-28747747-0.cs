    private void CategorizeButton_Click(object sender, EventArgs e)
    {
        switch (CategoryComboBox.SelectedIndex)
        {
            case 0: // Category 1
                // Code to send to Category 1
                break;
            case 1: // Category 2, repeat as necessary
                // Code to send to Category 2
                break;   
            default:
                MessageBox.Show("Please select a category!");
                CategoryComboBox.Focus();
                return;
        }
    }

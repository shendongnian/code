        if (!string.IsNullOrEmpty(partsTextBox.Text))
        {
            if(!decimal.TryParse(partsTextBox.Text, out partsCost))
            {
                MessageBox.Show("Invalid input for parts");
            }
        }

    public void btnButton_Clicked(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(textBox.Text))
        {
            MessageBox.Show("You did not enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox.Focus();
            return; // <=== This exits the btnButton_Clicked method until the button is clicked again
        }
        // Do stuff here if text *was* entered
    }

    private void YurTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                YourButton_Click(this, new EventArgs());
            }
        }

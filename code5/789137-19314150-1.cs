    private void ContentTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Control && e.KeyCode == Keys.A)
        {
            ContentTextBox.SelectAll();
        }
    }

    private void FormMain_KeyPress(object sender, KeyPressEventArgs e)        
    {
        if (e.KeyChar == (char)Keys.Enter && ModifierKeys == Keys.Control)
        {
            MessageBox.Show("e");
        }
    }

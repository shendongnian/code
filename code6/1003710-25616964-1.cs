    private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && Control.ModifierKeys == Keys.Control)
        {
            e.Handled = false;
            MessageBox.Show("Ok KeyDown");
        }
    }

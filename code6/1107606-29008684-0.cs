    private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            richTextBox2.SelectedText = DateTime.Now.ToString() + " --";
            e.Handled = true;
        }
    }

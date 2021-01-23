    // Navigates to the URL in the address box when 
    // the ENTER key is pressed while the ToolStripTextBox has focus.
    private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Navigate(toolStripTextBox1.Text);
        }
    }

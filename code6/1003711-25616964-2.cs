    private bool keydowncalled = false;
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        keydowncalled = false;
            
        if (e.KeyData == (Keys.Control | Keys.Enter))
        {
            keydowncalled = true;
            MessageBox.Show("Ok KeyDown");
        }
    }
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (keydowncalled == true)
        {
            // Stop the newline from being entered into the control.
            e.Handled = true;
        }
    }

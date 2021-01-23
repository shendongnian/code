    public void Form_Load(object sender, EventArgs e)
    {
        txtsample1.KeyPress += ValidateKeyPress;
        txtsample2.KeyPress += ValidateKeyPress;
    }
    private void ValidateKeyPress(object sender, KeyPressEventArgs e)
    {
        // sender is the textbox the keypress happened in
        if (!Char.IsDigit(e.KeyChar)) //Make sure the entered key is a number (0-9)
        {
            // Tell the text box that the key press event was handled, do not process it
            e.Handled = true;
        }
    }
    

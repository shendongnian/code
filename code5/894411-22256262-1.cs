    bool enterKeyPressed = false;
    private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
    {
        enterKeyPressed = (e.KeyChar == (char)Keys.Enter);
    }
    private void txtMessage_TextChanged(object sender, EventArgs e)
    {
        if (enterKeyPressed)
        {
        }
    }

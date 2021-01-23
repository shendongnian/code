    private void TextBox1KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.T || e.KeyCode == Keys.M)
        {
            e.SuppressKeyPress = true;
            Button1Click(this, EventArgs.Empty);
        }
    }

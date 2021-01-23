    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        var regex = new Regex(@"[^a-zA-Z0-9\s]");
        if (regex.IsMatch(e.KeyChar.ToString()))
        {
            e.Handled = true;
        }
    }

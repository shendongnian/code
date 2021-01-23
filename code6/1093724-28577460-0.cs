    private readonly HashSet<char> _enteredChars = new HashSet<char>();
    private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
    {
        if ((char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-') &&
            _enteredChars.Add(e.KeyChar))
        {
            return;
        }
        else
        {
            e.Handled = e.KeyChar != (char)Keys.Back;
            MessageBox.Show("X Origin Can Only Accepts Numbers, a Point '.' and a minus '-'", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

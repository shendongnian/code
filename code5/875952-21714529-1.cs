    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        var numericUpDown = (NumericUpDown)sender;
        decimal corners = numericUpDown.Value;
        if (corners < 13)
        {
            numericUpDown.BackColor = Color.White;
        }
    ...

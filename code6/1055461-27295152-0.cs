    private List<int> hexValues = new List<int>();
    private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            hexValues.Add(Convert.ToInt32(numericUpDown1.Value));
            
            // Reset the value.
            numericUpDown1.Value = Decimal.Zero;
        }
    }

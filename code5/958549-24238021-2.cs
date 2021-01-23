    private void numericUpDown1_Click(object sender, EventArgs e)
    {
        decimal old = numericUpDown1.Value;
        if (numericUpDown1.Tag != null) old = (decimal)numericUpDown1.Tag;
        if (old == numericUpDown1.Value && old == numericUpDown1.Maximum)
            numericUpDown1.Value = numericUpDown1.Minimum;
        else if (old == numericUpDown1.Value && old == numericUpDown1.Minimum)
            numericUpDown1.Value = numericUpDown1.Maximum;
        numericUpDown1.Tag = numericUpDown1.Value;
    }

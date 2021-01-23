    void Form5_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
            MessageBox.Show("A pressed");
        else if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.F1)
            MessageBox.Show("Combination of ALt and F1 pressed");
    }

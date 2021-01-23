    private Color entryColor;
    
    private void yellowColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        entryColor = Color.Yellow;
    }
    
    private void button_enter(object sender, EventArgs e)
    {
        Button b = (Button) sender;
        if (b.Enabled)
        {
            if (turn)
            {
                b.ForeColor = entryColor;
                b.Text = "X";
            }
            else
            {
                b.ForeColor = Color.Blue;
                b.Text = "O";
            }
        }
    }

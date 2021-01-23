    private void button1_Click(object sender, EventArgs e)
    {
        SendKeys.Send("{SUBTRACT}");
    }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Subtract)
            this.UltraGrid1.Rows.CollapseAll(true);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Right)
            button1.PerformClick();
        else if (e.KeyCode == Keys.Left)
            button2.PerformClick();
        else if...
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
        foreach (Button btn in Controls.OfType<Button>())
        {
            btn.MouseEnter += new System.EventHandler(btn_MouseEnter);
            btn.MouseLeave += new System.EventHandler(btn_MouseLeave );
        }
    }

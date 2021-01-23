    foreach (Button btn in Controls.OfType<Button>())
    {
        btn.MouseEnter += new System.EventHandler(btn_MouseEnter);
        btn.MouseLeave += new System.EventHandler(btn_MouseLeave );
    }
    private void btn_MouseEnter(object sender, System.EventArgs e) 
    {
        var senderButton = (Button)sender;
        senderButton.Width += 30;
    }
    private void btn_MouseLeave (object sender, System.EventArgs e) 
    {
        var senderButton = (Button)sender;
        senderButton.Width -= 30;
    }

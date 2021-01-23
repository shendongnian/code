    Button b1 = new Button();
    Button b2 = new Button();
    b2.Visible = false;
    b1.Click = b1_Click;
    private void b1_Click(object sender, EventArgs e)
    {
        b2.Visible = true;
    }

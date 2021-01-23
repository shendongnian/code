    private void timer1_Tick(object sender, EventArgs e)
    {
        if (button1.BackColor == Color.Gray)
        {
            button1.BackColor = Color.Red;
        }
        else
        {
            button1.BackColor = Color.Gray;
        }
    }

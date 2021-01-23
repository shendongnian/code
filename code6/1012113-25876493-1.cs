    // a class level flag to cool things down
    bool waiting = false;
    private void MouseScroll (object sender, MouseEventArgs e)
    {
        if (waiting ) return;
        // calculate the position by screen coordinates as we have diffentent senders
        int mx = MousePosition.X - this.Left - panel1.Left;
        int my = MousePosition.Y - this.Top - panel1.Top - (this.Height - this.ClientSize.Height );
        int nearness = 22;
        int scrollAmount = 40;
        if (panel1.ClientRectangle.Right - mx < nearness)
        {
            flowLayoutPanel1.Left -= scrollAmount ;
            waiting = true;
        }
        else if (mx - panel1.ClientRectangle.Left < nearness)
        {
            flowLayoutPanel1.Left += scrollAmount ;
            waiting = true;
        }
        else if ( panel1.ClientRectangle.Bottom - my < nearness)
        {
            flowLayoutPanel1.Top -= scrollAmount ;
            waiting = true;
        }
        else if (my - panel1.ClientRectangle.Top < nearness)
        {
            flowLayoutPanel1.Top += scrollAmount ;
            waiting = true;
        }
        if (waiting) timer1.Start();
    }

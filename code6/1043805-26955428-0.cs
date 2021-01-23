    void setBorder(Control ctl, Color col, int width, BorderStyle style)
    {
        if (col == Color.Transparent)
        {
            Panel pan = ctl.Parent as Panel;
            if (pan == null) { throw new Exception("control not in border panel!");}
            ctl.Location = new Point(pan.Left + width, pan.Top + width);
            ctl.Parent = pan.Parent;
            pan.Dispose();
        }
        else
        {
            Panel pan = new Panel();
            pan.BorderStyle = style; 
            pan.Size = new Size(ctl.Width + width * 2, ctl.Height + width * 2);
            pan.Location = new Point(ctl.Left - width, ctl.Top - width);
            pan.BackColor = col;
            pan.Parent = ctl.Parent;
            ctl.Parent = pan;
            ctl.Location = new Point(width, width);
        }
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Size size =  panel1.ClientSize;
        if (panelLocked)
        {
            // draw a full size cross-hei cursor over the whole Panel
            // change this to suit your own needs!
            e.Graphics.DrawLine(Pens.Red, 0, mouseCursor.Y, size.Width - 1, mouseCursor.Y);
            e.Graphics.DrawLine(Pens.Red, mouseCursor.X, 0, mouseCursor.X, size.Height);
        }
        // expensive drawing, you insert your own stuff here..
        else
        {
            List<Pen> pens = new List<Pen>();
            for (int i = 0; i < 111; i++)
                pens.Add(new Pen(Color.FromArgb(R.Next(111), 
                         R.Next(111), R.Next(111), R.Next(111)), R.Next(5) / 2f));
            for (int i = 0; i < 11111; i++)
                e.Graphics.DrawEllipse(pens[R.Next(pens.Count)], R.Next(211), 
                                       R.Next(211), 1 + R.Next(11), 1 + R.Next(11));
        }
    }

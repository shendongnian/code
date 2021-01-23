    Point bgn1 = new Point(5, 5);
    Point end1 = new Point(5, 5);
    Point bgn2 = new Point(0, 0);
    Point end2 = new Point(0, 0);
    private void Form1_Load(object sender, EventArgs e)
    {
        Point pnt, pntscr;
        pnt.X = 5;
        pnt.Y = 5;
        pntscr = Panel1.PointToScreen(pnt);
        bgn2 = Panel2.PointToClient(pntscr);
        end2 = bgn2;
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        end1.X = e.X;
        end1.Y = e.Y;
        Point pntscr;
        pntscr = Panel1.PointToScreen(end1);
        end2 = Panel2.PointToClient(pntscr);
    }
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        panel1.Refresh();
        panel2.Refresh();
    }
    private void panel2_MouseDown(object sender, MouseEventArgs e)
    {
        end2.X = e.X;
        end2.Y = e.Y;
        Point pntscr;
        pntscr = Panel2.PointToScreen(end2);
        end1 = Panel1.PointToClient(pntscr);
    }
    private void panel2_MouseUp(object sender, MouseEventArgs e)
    {
        panel1.Refresh();
        panel2.Refresh();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawLine(Pens.Red, bgn1, end1);
    }
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawLine(Pens.Red, bgn2, end2);
    }

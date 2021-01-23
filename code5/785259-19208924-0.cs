    private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            Pen myPen = new Pen(Color.Black, 1);
            Point sp = new Point(5, 5);//starting point sp
            Point ep = new Point(100, 100);//ending point ep
            //Paint it on panel
            g = panel1.CreateGraphics();//tells compiler that we are going to draw on this very form
            g.DrawLine(myPen, sp, ep);
            //Paint it on panel
            g = panel1.CreateGraphics();
            g.DrawEllipse(myPen, 0, 0, 90, 90);
        }

    // Little helper method :)
    private static void Swap<T>(ref T t1, ref T t2)
    {
        T temp = t1;
        t1 = t2;
        t2 = t1;
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g1 = e.Graphics;
        g1.DrawImage(bitmap, 0, 0, x1, y1);
        if (action)
        {
            //g.setColor(Color.White);
            if (xe < xs)
            {
                Swap(ref xs, ref xe);
            }
            if (ye < ys)
            {
                Swap(ref ys, ref ye);
            }
            g1.DrawRectangle(Pens.White, xs, ys, (xe - xs), (ye - ys));
        }
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
       // e.consume();
        if (action)
        {
            xe = e.X;
            ye = e.Y;
            Invalidate();
            //repaint();
        }
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        action = true;
        // e.consume();
        if (action)
        {
            xs = xe = e.X;
            ys = ye = e.Y;
            Invalidate();
        }
    }
 

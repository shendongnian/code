    //.. 
    Pen pen = new Pen(Color.Red, 6);
    g.DrawLine(pen, new Point(50 + currentX - lastX, 80), new Point(450 + currentX - lastX, 80));
    }
    // variables to keep mouse state, very quick and dirty
    int lastX = 0; int currentX = 0; 
    
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
       // hittest omitted
       currentX = e.X;
    }
    
    private void panel1_MouseUp(object sender, MouseEventArgs e)
    {
       // hittest omitted
       lastX = currentX;
       currentX = e.X;
       // this triggers the paint event
       // (invalidating much more than needed)
       panel1.Invalidate();
    }

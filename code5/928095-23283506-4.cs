    for(int i = 0; i < 5; i++)
    {
    	Label l = new Label();
    	l.MouseDown += l.MouseDown;
    	l.MouseMove += l.MouseMove;
    	l.MouseUp += l.MouseUp;
    	panel1.Controls.Add(l);
    }
 }   
    void l_MouseDown(object sender, MouseEventArgs e)
    {
    	isMouseDown = true;
    	lastPoint = e.Location;
    }
    
    void l_MouseMove(object sender, MouseEventArgs e)
    {
    	if (isMouseDown)
            {
                panel1.Location = new Point(
                    (
                    panel1.Location.X + e.X) - lastPoint.X,
                    (panel1.Location.Y + e.Y) - lastPoint.Y);
    
    	    ((Label)sender).Location = new Point(((Label)sender).Location.X + e.X) - lastPoint.X, ((Label)sender).Location.Y + e.Y) - lastPoint.Y));
    
                this.Update();
            }
    }
    
    void l_MouseUp(object sender, MouseEventArgs e)
    {
    	isMouseDown = false;
    }

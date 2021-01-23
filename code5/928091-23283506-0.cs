    for(int i = 0; i < 10; i++)
    {
       Label label = new Label();
       label.MouseDown += label_MouseDown;
       label.MouseMove += label_MouseMove;
       label.MouseUp += label_MouseUp;
       label.MouseEnter += label_MouseEnter;
    
       panel1.Controls.Add(label);
    }
    void label_MouseUp(object sender, MouseEventArgs e)
    {
        isMouseDown = false;
    }
    void label_MouseMove(object sender, MouseEventArgs e)
    {
        if(isMouseDown)
        {
            ((Label)sender).Location = new Point(
                (
                ((Label)sender).Location.X + e.X) - lastPoint.X, 
                (((Label)sender).Location.Y + e.Y) - lastPoint.Y
                );
            this.Update();
        }
    }
    void label_MouseDown(object sender, MouseEventArgs e)
    {
        isMouseDown = true;
        lastPoint = e.Location;
    }

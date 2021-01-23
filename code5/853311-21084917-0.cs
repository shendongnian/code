    Point cntr = new Point(this.Width/2, this.Height/2); // cntr Points Center of Circle
    // Count gives Number of Buttons        
    int count = 25; 
    // angle gives angle Between each Button
    double angle = 360/(double)count; 
    int radius = 150; // Circle's Radius
    for (int i = 0; i < count; i++)
    {
        Button button = new Button();
        button.Text = "Button " + i;
        button.Location = new Point((int)(cntr.X + radius * Math.Cos((angle * i) * Math.PI / 180)),
            (int)(cntr.Y + radius * Math.Sin((angle * i) * Math.PI / 180)));
        this.Panle1.Controls.Add(button);
    }

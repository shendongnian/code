    if (poscount > 15)
    {
        // to see if point is close to an object
        Point iPoint = new Point((int)point2.X, (int)point2.Y);
        if (this.GetChildAtPoint(iPoint) != null)
        {
            label1.Text = "I found an object";                                      
        }
        else
        {
            label1.Text = " no object found";
        }
    }

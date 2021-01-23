    double imgWidth = 0.0;
    double imgHeight = 0.0;
    double imgOffsetX = 0.0;
    double imgOffsetY = 0.0;
    double dRatio = pb.Image.Height / (double)pb.Image.Width; //dRatio will not change during resizing
    pb.MouseClick += (ss, ee) =>
    {
        test30x30.Location = new Point(ee.X - test30x30.Image.Width / 2, ee.Y - test30x30.Image.Height);
        //x = ...
        //y = ...
    };
    this.Resize += (ss, ee) =>
    {
        pb.Size = new Size(this.ClientSize.Width - 100, this.ClientSize.Height - 100);  
    };
   
    pb.SizeChanged += (ss, ee) =>
    {
        //recalculate image size and offset
        if (pb.Height / pb.Width > dRatio)
        {
            imgWidth = pb.Width;
            imgHeight = pb.Width * dRatio;
                    
            imgOffsetX = 0.0;
            imgOffsetY = (pb.Height - imgHeight) / 2;
        }
        else
        {
            imgHeight = pb.Height;
            imgWidth = pb.Height / dRatio;
            imgOffsetY = 0.0;
            imgOffsetX = (pb.Width - imgWidth) / 2;
        }
        //test30x30.Location = ...
    }

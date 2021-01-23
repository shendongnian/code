        Graphics g = e.Graphics;                   
        Pen blue = new Pen(Color.Blue, 3);
        // Original form size is (500,300)
        // 
        // Rectangle Width is 100, Height is 50
        // 1st Rectangle is at (10,20), 2nd is at (150,20)
        // So proportionally, rect1 is (10/500, 20/300, 100/500, 50/300)
        //     = (0.02, 0.0667, 0.2, 0.1667)
        // and rect is (150/500, 20/300, 0.2, 0.1667) = (0.3, 0.0667, 0.2, 0.1667)
        //
        // note that the y, width, and height is the same for both rectangles
        float rectWidth = 0.2f * Width, rectHeight = 0.1667f * Height,
            x1 = 0.02f * Width, x2 = 0.3f * Width, y = 0.0667f * Height;
        g.DrawRectangle(blue, x1, y, rectWidth, rectHeight);
        g.FillRectangle(Brushes.Red, x2, y, rectWidth, rectHeight);
        base.OnPaint(e);

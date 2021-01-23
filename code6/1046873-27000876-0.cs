        Cairo.Rectangle imageRectangle = new Cairo.Rectangle(50, 100, width, height);
        ctx.NewPath();
        Cairo.ImageSurface imgSurface = new Cairo.ImageSurface("C:/Temp/Image.png");
        
        float xScale = (float)imageRectangle.Width / (float)imgSurface.Width;
        float yScale = (float)imageRectangle.Height / (float)imgSurface.Height;
        //Reposition the image to the rectangle origin
        ctx.Translate(imageRectangle.X, imageRectangle.Y);
        ctx.Scale(xScale, yScale);
        ctx.SetSource(imgSurface); 
        ctx.Paint();

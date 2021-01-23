    imageResult.ROI = new Rectangle(0, 0, image1.Width, image1.Height);
    image1.CopyTo(imageResult);
    imageResult.ROI = new Rectangle(0, image1.Height, image2.Width, image2.Height);
    image2.CopyTo(imageResult);
    imageResult.ROI = Rectangle.Empty;

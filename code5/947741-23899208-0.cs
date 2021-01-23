    Image imageA = new System.Drawing.Image("ImageA.png");
    Image imageB = new System.Drawing.Image("ImageB.png");
    int imageASize = imageA.Size.Height * imageA.Size.Width;
    int imageBSize = imageB.Size.Height * imageB.Size.Width;
    string ratio = string.Format("Image B is {0}% of the size of image A", ((imageBSize / ImageASize)*100).ToString("#0"));

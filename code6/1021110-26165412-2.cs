    public void SomeMethodName()
    {
        Image img = System.Drawing.Image.FromStream(myStream);
        //Send orig image
        sendImageToAmazon(img);
        //Send resized images
        sendImageToAmazon(ImageResize(img, 1280, 960));
        sendImageToAmazon(ImageResize(img, 640, 480));
        sendImageToAmazon(ImageResize(img, 320, 240));
    }
    public void sendImageToAmazon(image img)
    {
        //Your current code
    }
    public image ImageResize(image orig, int width, int height)
    {
        //Image resizer code.
    }

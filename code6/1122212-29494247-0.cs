    public MyImage(System.IO.Stream input)
    {
        var image = System.Drawing.Image.FromStream(input);
        _wrappedImage = new System.Drawing.Bitmap(image);
        // input stream may now be closed
    }

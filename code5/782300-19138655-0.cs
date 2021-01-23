    public static Size MeasureText(Graphics graphicsDevice, String text, Font font)
    {
        System.Drawing.SizeF textSize = graphicsDevice.MeasureString(text, font);
        int width = (int)Math.Ceiling(textSize.Width);
        int heigth = (int)Math.Ceiling(textSize.Height);
    
        Size size = new Size(width, heigth);
        return size;
    }

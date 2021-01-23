    private static Point Translate(Point point, Size from, Size to)
    {
        return new Point((point.X * to.Width) / from.Width, (point.Y * to.Height) / from.Height);
    }
    private static void Main(string[] args)
    {
        Size fromResolution = new Size(1920, 1200);//From resolution
        Size toResolution = new Size(1280, 800);//To resolution
        Console.WriteLine(Translate(new Point(100, 100), fromResolution, toResolution));
        //Prints 66,66
    }

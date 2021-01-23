    pd.PrintPage += (s, eventArgs) =>
    {
        Image i = Image.FromFile(newFile);
        Point p = new Point(0, 0);
        eventArgs.Graphics.DrawImage(i, p);
    };  // <-- here

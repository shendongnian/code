    PrintDocument pd = new PrintDocument();
    pd.DefaultPageSettings.PrinterSettings.PrinterName = "Printer Name";
    pd.DefaultPageSettings.Landscape = true; //or false!
    pd.PrintPage += (sender, args) =>
    {
        Image i = Image.FromFile(@"C:\...\...\image.jpg");
        Rectangle m = args.MarginBounds;
        
        if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
        {
            m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
        }
        else
        {
            m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
        }
        args.Graphics.DrawImage(i, m);
    };
    pd.Print();

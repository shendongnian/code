    int desired_x_dpi = 600;
    int desired_y_dpi = 600;
    
    Image img = rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
    
    System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
    pd.PrintPage += (sender, args) =>
    {
        args.Graphics.DrawImage(img, args.MarginBounds);
    };
    pd.Print();

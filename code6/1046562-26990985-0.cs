    int page = 0;
    pd.PrintPage += (sender, e) =>
    {
        if (page == 0)
        {
            // Print front side
            _renderObject.RenderPrinter(e.Graphics);
            e.HasMorePages = true;
        }
        else if (page == 1)
        {
            // TODO: Print back side
            e.HasMorePages = false;
        }
        page += 1;
    };

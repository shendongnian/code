    var reader = new PdfReader(foregroundFile);
    
    RectangleJ customerIdRectangle = new RectangleJ(0, 495, 108, 27);
    
    for (int i = 1; i <= reader.NumberOfPages; i++)
    {
        RenderFilter[] filters = new RenderFilter[1];
        LocationTextExtractionStrategy regionFilter = new LocationTextExtractionStrategy();
        filters[0] = new RegionTextRenderFilter(customerIdRectangle);
        FilteredTextRenderListener strategy = new FilteredTextRenderListener(regionFilter, filters);
        string output = "";
        output = PdfTextExtractor.GetTextFromPage(reader, i, strategy);
        Console.WriteLine(output);
    }

    System.util.RectangleJ rect = new System.util.RectangleJ(70, 80, 420, 500);
    RenderFilter[] filter = {new RegionTextRenderFilter(rect)};
    ITextExtractionStrategy strategy = new FilteredTextRenderListener(
            new LocationTextExtractionStrategy(), filter);
    text = PdfTextExtractor.GetTextFromPage(reader, 1, strategy);

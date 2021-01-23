    RenderFilter[] filter = {new RegionTextRenderFilter(rect)};
    ITextExtractionStrategy strategy;
    StringBuilder sb = new StringBuilder();
    for (int i = 1; i <= reader.NumberOfPages; i++) {
        strategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), filter);
        sb.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i, strategy));
    }

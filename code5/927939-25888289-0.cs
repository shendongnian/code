     List<String> pdfText = new List<string>();
    for (int page = 1; page <= reader.NumberOfPages; page++)
    {
        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
        PdfTextExtractor.GetTextFromPage(reader, page, its);
    
        strPage = its.GetResultantText();
    
        pdfText.Add(strPage);
    }

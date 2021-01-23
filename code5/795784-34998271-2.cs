    using PdfSharp.Pdf; // PdfDocument, PdfPage
    using PdfSharp.Drawing; // XGraphics, XFont, XBrush, XRect
                            // XStringFormats
    
    // Create a new PdfDocument.
    PdfDocument document = new PdfDocument();
    // Add five pages to the document.
    for(int i = 0; i < 5; ++i)
        document.AddPage();
    // Make a font and a brush to draw the page counter.
    XFont font = new XFont("Verdana", 8);
    XBrush brush = XBrushes.Black;
    // Add the page counter.
    string noPages = document.Pages.Count.ToString();
    for(int i = 0; i < document.Pages.Count; ++i)
    {
        PdfPage page = document.Pages[i];
    
        // Make a layout rectangle.
        XRect layoutRectangle = new XRect(0/*X*/, page.Height-font.Height/*Y*/, page.Width/*Width*/, font.Height/*Height*/);
        using (XGraphics gfx = XGraphics.FromPdfPage(page))
        {
            gfx.DrawString(
                "Page " + (i+1).ToString() + " of " + noPages,
                font,
                brush,
                layoutRectangle,
                XStringFormats.Center);
        }
    }

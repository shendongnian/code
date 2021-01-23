    using(PdfDocument doc = new PdfDocument()){
        PdfPage page = doc.AddPage();
        using(XGraphics gfx = XGraphics.FromPdfPage(page)){
            gfx.DrawRectangle(XBrushes.Black, new XRect(0, 0, page.Width.Point, page.Height.Point));
        }
        doc.Save("pdfDocument.pdf");
    }

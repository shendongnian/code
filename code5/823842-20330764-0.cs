    // Create the output document
    PdfDocument outputDocument = new PdfDocument();
    
    // Show single pages
    // (Note: one page contains two pages from the source document)
    outputDocument.PageLayout = PdfPageLayout.SinglePage;
    
    // Open the external document as XPdfForm object
    XPdfForm form = XPdfForm.FromFile(filename);
    
    for (int i = 0; i < form.PageCount; i++)
    {
        // Add a new page to the output document
        PdfPage page = outputDocument.AddPage();
        page.Orientation = PageOrientation.Landscape;
        double width = page.Width;
        double height = page.Height;
    
        int rotate = page.Elements.GetInteger("/Rotate");
    
        XGraphics gfx = XGraphics.FromPdfPage(page);
    
        XRect box = new XRect(0, 0, width, height * 2);
        // Draw the page identified by the page number like an image
        gfx.DrawImage(form, box);
    }
    
    // Save the document...
    filename = "RotatedAndStretched_tempfile.pdf";
    outputDocument.Save(filename);

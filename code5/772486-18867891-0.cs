    private void GeneratePDF(string filename, string imageLoc)
    {
        PdfDocument document = new PdfDocument();
        // Create an empty page or load existing
        PdfPage page = document.AddPage();
        // Get an XGraphics object for drawing
        XGraphics gfx = XGraphics.FromPdfPage(page);
        DrawImage(gfx, imageLoc, 50, 50, 250, 250);
        // Save and start View
        document.Save(filename);
        Process.Start(filename);
    }
    void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
    {
        XImage image = XImage.FromFile(jpegSamplePath);
        gfx.DrawImage(image, x, y, width, height);
    }

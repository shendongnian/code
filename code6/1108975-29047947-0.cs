    using Cyotek.GhostScript.PdfConversion;
    private Bitmap PdfToBitmap(String path)
    {
        Pdf2Image pdfimage = new Pdf2Image();
        pdfimage.Settings.Dpi = 300;
        pdfimage.PdfFileName = path;
        Bitmap bitmap = pdfimage.GetImage();
        return bitmap;
    }

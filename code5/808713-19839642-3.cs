    using (var fsImage = File.Open(tiff_path, FileMode.Open, FileAccess.Read, FileShare.None))
    {
        var output = new PdfDocument();
        var input = PdfReader.Open(template_path, PdfDocumentOpenMode.Import);
        
        var page = input.Pages[0];
        output.AddPage(page);
        page = output.Pages[0];
        
        var gfx = XGraphics.FromPdfPage(page);
        
        var bitmapSource = new BitmapImage();
        bitmapSource.BeginInit();
        bitmapSource.StreamSource = fsImage;
        bitmapSource.EndInit();
        using (var image = XImage.FromBitmapSource(bitmapSource))
        {
            gfx.DrawImage(image, 500, 200, 400, 400);
        }
        
        output.Save(destination_path);
        output.Close();
    }

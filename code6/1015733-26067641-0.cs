    StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///assets/demo.pdf"));
    PdfDocument pdfDoc = await PdfDocument.LoadFromFileAsync(file);
    PdfPage pdfPage = pdfDoc.GetPage(0);
    using (IRandomAccessStream stream = new InMemoryRandomAccessStream())
    {
        PdfPageRenderOptions options = new PdfPageRenderOptions();
        await pdfPage.RenderToStreamAsync(stream, options);
        WriteableBitmap wb = new WriteableBitmap((int)pdfPage.Size.Height, (int)pdfPage.Size.Width);
        await wb.SetSourceAsync(stream);
        using (Stream pixels = wb.PixelBuffer.AsStream())
        {
            pixels.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < pixels.Length; i++)
            {
                byte subPixel = (byte)pixels.ReadByte();
                // WB pixels are RGBA. Only change RGB, not A
                if ((i + 1) % 4 != 0)
                {
                    // write over the same pixel we just read
                    pixels.Seek(-1, SeekOrigin.Current);
                    // write the modified pixel (inverted colour in this case)
                    pixels.WriteByte((byte)(byte.MaxValue - subPixel));
                }
            }
        }
        // Display the page on an Image in our Xaml Visual Tree
        img.Source = wb;
    }

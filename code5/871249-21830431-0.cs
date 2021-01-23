    private async void renderPdf(StorageFile file)
        {
            imagePanel.Children.Clear();
            PdfDocument pdf = await PdfDocument.LoadFromFileAsync(file);
            for (uint pageNum = 0; pageNum < pdf.PageCount; pageNum++)
            {
                PdfPage page = pdf.GetPage(pageNum);
                InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                await page.RenderToStreamAsync(stream);
                BitmapImage source = new BitmapImage();
                source.SetSource(stream);
                Image pdfPage = new Image();
                pdfPage.HorizontalAlignment = HorizontalAlignment.Center;
                pdfPage.VerticalAlignment = VerticalAlignment.Center;
                pdfPage.Height = page.Size.Height;
                pdfPage.Width = page.Size.Width;
                pdfPage.Margin = new Thickness(0, 0, 0, 5);
                pdfPage.Source = source;
                imagePanel.Children.Add(pdfPage);
                
            }
        } 

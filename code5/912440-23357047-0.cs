      using (var rasterizer = new PdfRasterizer(new Foxit.PDF.Rasterizer.InputPdf(pdfData)))
                {
                    // Create a JpegImageFormat object.
                    var jpegImageFormat = new JpegImageFormat(100);
    
                    // Create a FixedImageSize object with required width and height.
                    var imageSize = new PercentageImageSize(400);
    
                    // Save the image.
                    var imagePages = rasterizer.Draw(jpegImageFormat, imageSize);
    
                    using (var pd = new PrintDocument())
                    {
                        var margins = new Margins(0, 40, 0, 40);
                        pd.DefaultPageSettings.Margins = margins;
                        pd.DefaultPageSettings.Color = true;
                        pd.DefaultPageSettings.Landscape = false;
    
                        var pageNumber = 0;
    
                        pd.PrintPage += (sender, args) =>
                        {
                            PrintPage(pageNumber, text1, text2, imagePages[pageNumber], args);
                            if (pageNumber < imagePages.Count())
                            {
                                pageNumber++;
                                args.HasMorePages = pageNumber != imagePages.Count();
                            }
                        };
    
                        pd.Print();
                    }
                }

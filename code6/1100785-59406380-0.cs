            var output = new PdfDocument();
            var outputPage = output.AddPage();            
            using (var stream = new MemoryStream(Convert.FromBase64String(pdfBase64String)))
            {
                using (var input = XPdfForm.FromStream(stream))
                {
                    outputPage.Height = input.PointWidth;
                    outputPage.Width = input.PointHeight;
                    using (var graphics = XGraphics.FromPdfPage(outputPage))
                    {
                        graphics.RotateAtTransform(90, new XPoint(input.PointHeight / 2, input.PointHeight / 2));
                        graphics.DrawImage(input, new XRect(0, 0, input.PointWidth, input.PointHeight));
                        
                    }
                }
            }

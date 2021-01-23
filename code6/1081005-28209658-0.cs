      using PdfSharp.Pdf;
      using PdfSharp.Drawing;
      using ImageTools.IO.Jpeg;
       private void btnCBEPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "PDF file format|*.pdf";
                // Save the document...
                if (d.ShowDialog() == true)
                {
                    PdfDocument document = new PdfDocument();
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    ExtendedImage myImage = LayoutRoot.ToImage();
                    page.Width = ((ImageTools.ImageBase)(myImage)).Bounds.Width - 300;
                    page.Height = ((ImageTools.ImageBase)(myImage)).Bounds.Height;
                    MemoryStream mstream = new MemoryStream();
                    JpegEncoder encoder = new JpegEncoder();
                    encoder.Quality = 90;
                    encoder.Encode(myImage, mstream);
                    mstream.Seek(0, SeekOrigin.Begin);
                    XImage pdfImg = XImage.FromStream(mstream);
                    gfx.DrawImage(pdfImg, 0, 0);
                    //btnSave.Visibility = Visibility.Visible;
                    btnCBEPrint.Visibility = Visibility.Visible;
                    document.Save(d.OpenFile());
                }
            }
            catch (Exception ex)
            {
              
            }
        }

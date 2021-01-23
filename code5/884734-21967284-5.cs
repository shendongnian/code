    protected void btn_print_Click(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        int width = 850;
        int height = 550;
        Thumbnail1 thumbnail = new Thumbnail1(url, 990, 1000, width, height);
        using (Bitmap image = thumbnail.GenerateThumbnail())
            convertToPdf(image);
    }
    public void convertToPdf(Image image)
    {
        using (PdfDocument doc = new PdfDocument())
        {
            System.Drawing.Size size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
            PdfPage pdfPage = new PdfPage();
            pdfPage.Orientation = PageOrientation.Landscape;
            doc.Pages.Add(pdfPage);
            using (XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]))
            {
                using (XImage img = XImage.FromGdiPlusImage(image))
                {
                    xgr.DrawImage(img, 0, 0);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        doc.Save(stream, false);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Length", stream.Length.ToString());
                        stream.WriteTo(Response.OutputStream);
                    }
                }
            }
        }
        Response.End();
    }

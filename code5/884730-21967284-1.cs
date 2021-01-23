    protected void btn_print_Click(object sender, EventArgs e)
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;
        int width = 850;
        int height = 550;
        Thumbnail1 thumbnail = new Thumbnail1(url, 990, 1000, width, height);
        Bitmap image = thumbnail.GenerateThumbnail();
        convetToPdf(image);
    }
    public void convertToPdf(Image image)
    {
        PdfDocument doc = new PdfDocument();
        System.Drawing.Size size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
        PdfPage pdfPage = new PdfPage();
        pdfPage.Orientation = PageOrientation.Landscape;
        doc.Pages.Add(pdfPage);
        //  XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4)
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
        XImage img = XImage.FromGdiPlusImage(image);
        xgr.DrawImage(img, 0, 0);
        Response.ContentType = "application/pdf";
        doc.Save(Response.OutputStream);
        xgr.Dispose();
        img.Dispose();
        doc.Close();
        Response.End();
    }

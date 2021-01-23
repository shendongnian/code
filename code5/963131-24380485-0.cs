    public FileResult Index()
    {
        var _pdfConverter = new PdfConverter { MediaType = "Print" };
        var url = Request.Url.AbsolutePath;
        var pdfBytes = _pdfConverter.GetPdfBytesFromUrl(url);
        return File(pdfBytes, "application/pdf", "bla.pdf");
    }

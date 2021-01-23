    public HttpResponseMessage Get(string url, string title)
    {
        byte[] pdfBytes;
        /* generate the pdf into pdfBytes */
        string cleanTitle = new Regex(@"[^\w\d_-]+").Replace(title, "_");
        string contentDisposition = string.Concat("attachment; filename=", cleanTitle, ".pdf");
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, pdfBytes, MediaTypeHeaderValue.Parse("application/pdf"));
        response.Content.Headers.ContentDisposition = ContentDispositionHeaderValue.Parse(contentDisposition);
        return response;
    }

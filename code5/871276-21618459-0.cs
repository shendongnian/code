    public HttpResponseMessage GetCustomerBarCodeLogo(String ID)
    {
        Barcode BC = new Barcode();
        Image img =BC.Encode(TYPE.CODE128, "123456789");
        var dataStream = new MemoryStream();
        img.Save(dataStream, ImageFormat.Png);
        dataStream.Position = 0;
        var result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new StreamContent(dataStream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        return result; 
    }

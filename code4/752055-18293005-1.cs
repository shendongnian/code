    // Create a Document object
    var document = new Document(PageSize.A4, 50, 50, 25, 25);
    // Create a new PdfWriter object, specifying the output stream
    var output = new MemoryStream();
    var writer = PdfWriter.GetInstance(document, output);
    // Open the Document for writing
    document.Open();
    var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(html), null);
    foreach (var htmlElement in parsedHtmlElements)
    {
        document.Add(htmlElement as IElement);
    }
    document.Close();
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition",  String.Format("attachment;filename=students{0}.pdf", YourStudendsPrintingId));
    Response.BinaryWrite(output.ToArray()); 

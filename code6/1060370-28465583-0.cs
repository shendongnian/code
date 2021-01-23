    string strHtml = String.Format("<h1>Hello World!</h1");
    HtmlToPdfConverter pdfConverter = new HtmlToPdfConverter();
    var pdfBytes = pdfConverter.GeneratePdf(strHtml);
    Response.ContentType = "application/pdf";
    Response.ContentEncoding = System.Text.Encoding.UTF8;
    Response.AddHeader("Content-Disposition", "Inline; filename=TEST.pdf");
    Response.BinaryWrite(pdfBytes);
    Response.Flush();
    Response.End();

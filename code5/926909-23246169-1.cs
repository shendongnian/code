    string htmlstr = "<html><body><h1>My First Heading</h1><p>My first paragraph.</p><table border=1><tr><td>1st</td><td>2nd</td></tr><tr><td>3rd</td><td>4th</td></tr></table></body></html>";
    //We'll store our final PDF in this
    byte[] bytes;
    //Read our HTML as a .Net stream
    using (var sr = new StringReader(htmlstr)) {
        //Standard PDF setup using a MemoryStream, nothing special
        using (var ms = new MemoryStream()) {
            using (var pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f)) {
                //Bind a parser to our PDF document
                using (var htmlparser = new HTMLWorker(pdfDoc)) {
                    //Bind the writer to our document and our final stream
                    using (var w = PdfWriter.GetInstance(pdfDoc, ms)) {
                        pdfDoc.Open();
                        //Parse the HTML directly into the document
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        //Grab the bytes from the stream before closing it
                        bytes = ms.ToArray();
                    }
                }
            }
        }
    }
    //Assuming that the above worked we can now finally modify the HTTP response
    Response.Clear();
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=BusinessUnit.pdf");
    Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
    //Send the bytes from the PDF
    Response.BinaryWrite(bytes);
    Response.End();

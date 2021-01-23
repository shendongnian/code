    //Do PDF stuff first
    //We'll put our final bytes here when we're done
    byte[] bytes;
    //Write to a MemoryStream so that we don't pollute the HTTP pipeline
    using (var ms = new MemoryStream()) {
        //This is all the same
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //Use our above MemoryStream instead of the OutputStream
        PdfWriter.GetInstance(pdfDoc, ms);
        //Same
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        //The above is done, get the byte representation of our PDF
        bytes = ms.ToArray();
    }
    //If the above works, change the HTTP stream to output the PDF
    Response.Clear(); //this clears the Response of any headers or previous output
    Response.Buffer = true; //ma
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=DataTable.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //Write our byte array
    Response.BinaryWrite(bytes);
    Response.End();

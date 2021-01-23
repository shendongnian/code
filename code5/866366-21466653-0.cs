    //Convert our control to HTML
    string buf;
    using (var sw = new StringWriter()) {
        using (var hw = new HtmlTextWriter(sw)) {
            Panel1.RenderControl(hw);
        }
        buf = sw.ToString();
    }
    //Sanity check
    if (String.IsNullOrWhiteSpace(buf)) {
        throw new ApplicationException("No content found");
    }
    //Create our PDF and get a byte array
    byte[] bytes;
    using (var ms = new MemoryStream()) {
        using (var pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f)) {
            using (var writer = PdfWriter.GetInstance(pdfDoc, ms)) {
                pdfDoc.Open();
                using (var htmlparser = new HTMLWorker(pdfDoc)) {
                    using (var sr = new StringReader(buf)) {
                        htmlparser.Parse(sr);
                    }
                }
                pdfDoc.Close();
            }
        }
        bytes = ms.ToArray();
    }
    //Output the PDF
    Response.Clear();
    Response.AddHeader("content-disposition", "attachment;filename=Quote.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.BinaryWrite(bytes);
    Response.End();

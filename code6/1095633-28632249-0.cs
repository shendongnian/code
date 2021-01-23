    //Will hold our PDF eventually
    Byte[] bytes;
    //HTML that we want to parse
    string html = "<table><tr><td>some contents</td></tr></table>";
    //Create a MemoryStream to write our PDF to
    using (var ms = new MemoryStream()) {
        //Create our document abstraction
        using (var ResultPDF = new Document(iTextSharp.text.PageSize.A4, 25, 10, 20, 30)) {
            //Bind a writer to our Document abstraction and our stream
            using (var writer = PdfWriter.GetInstance(ResultPDF, ms)) {
                //Open the PDF for writing
                ResultPDF.Open();
                //Parse our HTML using the old, obsolete, not support parser
                using (var sw = new StringWriter()) {
                    using (var hw = new HtmlTextWriter(sw)) {
                        using (var sr = new StringReader(html)) {
                            using (var htmlparser = new HTMLWorker(ResultPDF)) {
                                htmlparser.Parse(sr);
                            }
                        }
                    }
                }
                //Close the PDF
                ResultPDF.Close();
            }
        }
        //Grab the raw bytes of the PDF
        bytes = ms.ToArray();
    }
    //At this point, the bytes variable holds a valid PDF file.
    //You can write it disk:
    System.IO.File.WriteAllBytes("your file path here", bytes);
    //You can also send it to a browser:
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=WelcomeLetter.pdf");
    Response.BinaryWrite(bytes);
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //Never do the next line, it doesn't do what you think it does and actually produces corrupt PDFs
    //Response.Write(ResultPDF); //BAD!!!!!!
    Response.End();

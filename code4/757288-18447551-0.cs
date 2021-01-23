    Document document = new Document(PageSize.A4); 
     using (MemoryStream ms = new MemoryStream())
                {
                    PdfWriter.GetInstance(document, ms);
                    document.Open();
    System.Xml.XmlTextReader _xmlr;
                    if (String.IsNullOrEmpty(errorMsg))
                        _xmlr = new System.Xml.XmlTextReader(new StringReader(GetTransferedData(content)));
                    else
                        _xmlr = new System.Xml.XmlTextReader(new StringReader(@"<html><body>Error Message:" + errorMsg + "</body></html>"));
                    iTextSharp.text.html.HtmlParser.Parse(document, _xmlr);
                    document.Close();                 
                    ms.Flush();
                    byte[] data = ms.ToArray();
    
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(data);
                    Response.End();
                    ms.Close();
                }

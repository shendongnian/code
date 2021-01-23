      protected void ExportToPDFClick(object sender, EventArgs e)
    {
    
        Response.Clear(); 
    
        StringBuilder sb = new StringBuilder();
    
        StringWriter sw = new StringWriter(sb);
    
        HtmlTextWriter htw = new HtmlTextWriter(sw);
    
    
    
        gvCustomers.RenderControl(htw);
   
    
        Response.ContentType = "application/pdf";
    
        Response.AddHeader("content-disposition", "attachment; filename=MypdfFile.pdf"); 
    
        Document document = new Document();
        PdfWriter.GetInstance(document, Response.OutputStream);
    
        document.Open();
   
        string html = sb.ToString();
 
        XmlTextReader reader = new XmlTextReader(new StringReader(html));
    
        HtmlParser.Parse(document, reader);
        document.Close();
    
        sw.Close();
    
        Response.Flush();
    
        Response.End();
    }

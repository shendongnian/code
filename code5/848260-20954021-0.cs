    Response.ContentType = "application/pdf";
    
    Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
    
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    
    StringWriter sw = new StringWriter();
    
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
    grdLoanInquery.AllowPaging = false;
    
    grdLoanInquery.DataBind();
    
    grdLoanInquery.RenderControl(hw);
    
    StringReader sr = new StringReader(sw.ToString());
    
    Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
    
    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    
    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    
    pdfDoc.Open();
    
    htmlparser.Parse(sr);
    
    pdfDoc.Close();
    
    Response.Write(pdfDoc);
    
    Response.End();
    
  

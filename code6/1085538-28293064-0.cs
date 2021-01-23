        Response.Buffer = false;
    
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
 
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + filename");         
        mpp.myPDF(Response.OutputStream);  // PdfDocument...
        Response.End()

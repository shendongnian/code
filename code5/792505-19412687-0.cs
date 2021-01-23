    public FileContentResult GetDocument(string zipCode, string loanNumber, string classification, string fileName)
    {
        byte[] doc = _docService.GetDocument(zipCode, loanNumber, classification, fileName);
        string mimeType = "application/pdf"
        Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
        return File(doc, mimeType);
    } 

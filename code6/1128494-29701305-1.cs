    private void ShowPdf(byte[] strS)
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
    
        Response.BinaryWrite(strS);
        Response.End();
        Response.Flush();
        Response.Clear();
    }

    protected void AccessFile_Click(object sender, EventArgs e)
    {
        FileInfo pdf = new FileInfo(Server.MapPath("~/pdf/Newsletter01.pdf"));
        Response.ClearContent();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=" + pdf.Name);
        Response.AddHeader("Content-Length", pdf.Length.ToString());   
        Response.TransmitFile(pdf.FullName);
        Response.Flush();
        Response.End();
    }

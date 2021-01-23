    private void Button1_click(object sender, System.EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
        Response.TransmitFile(Server.MapPath("~/doc/help.pdf"));
        Response.End();
    }

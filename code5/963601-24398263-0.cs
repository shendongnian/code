    protected void gridExpenditures_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            var filePath = Server.MapPath("~/Match/Files/") + e.CommandArgument;
            var contentType = MimeTypes.GetContentType(filePath);
            if (string.IsNullOrEmpty(contentType))
            {
                contentType = "application/octet-stream";
            }
            Response.Clear();
            Response.ContentType = contentType;
            Response.AppendHeader("content-disposition", "FileName=" + e.CommandArgument);
            Response.TransmitFile(filePath);
            Response.End();
        }
    }

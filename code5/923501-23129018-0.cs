    protected void Attchdwnld_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // gets the clicked row of your GridView
        var row = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
        //gets the filename in the cliked row
        var attachmentNameLabel = row.FindControl("AttachmentFileName") as Label;
        //store it to lblMessage's Text
        lblMessage.Text = attachmentNameLabel.Text;
        var filePath = String.Format("C:\\Search\\{0}\\{1}\\{2}",
            stName, strtFolder, lblMessage.Text);
        var file = new System.IO.FileInfo(filePath);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
        else
        {
            Response.Write("This file does not exist.");
        }
    }

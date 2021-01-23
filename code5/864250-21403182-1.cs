    protected void btnUpload_OnClick(object sender, EventArgs e)
    {
        try
        {
            if (FileUploadContacts.HasFile)
            {
                FileUploadContacts.SaveAs(Server.MapPath("Uploads//") + FileUploadContacts.FileName);
                this.lblMessage.Text = "File uploaded Successfully!>";
            }
            else
            {
                this.lblMessage.Text = "File not uploaded!>";
            }
        }
        catch (Exception ex)
        {
            Logger.WriteException(ex);
        }
    }

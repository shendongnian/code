    private bool UploadFile()
    {
        string pathToSaveFile = Server.MapPath("~/Data/");
        string clientFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        string upload_data = pathToSaveFile + clientFileName;
        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
        {
            if (System.IO.File.Exists(upload_data))
            {
                //using Response.write
                Response.Write(@"<script type='text/javascript'>alert('Rename it please.');</script>");
                //ClientScriptManager
                var clientScript = Page.ClientScript;
                clientScript.RegisterClientScriptBlock(this.GetType(), "AlertScript", "alert('Rename it please.')'", true);
                //ScriptManger
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
		return false;
            }
            else
            {
                FileUpload1.PostedFile.SaveAs(System.IO.Path.Combine(pathToSaveFile, clientFileName));
            }
        }
        else
        {
            Response.Write("Not Available");
        }
	ViewState["FileName"] = clientFileName;
        return true;
    }

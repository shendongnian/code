protected void AnyUploader_FileUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        try
        {
            string path = "";
            if (Request.QueryString["uplCtrlID"] != null)
            {
                //uplCtrlID (the query string param we injected with the overriden JS function)
                //contains the ID of the uploader.
                //We'll use that to fire the appropriate event handler...
                if (Request.QueryString["uplCtrlID"] == AjaxFileUploadOne.ClientID)
                {      
                    /** different path assignment for each uploader **/
                    path = @"C:\Temp\FileUploaderOne\";
                    if (!Directory.Exists(path))  Directory.CreateDirectory(path);
                    AjaxFileUploadOne.SaveAs(path + e.FileName);                   
                }
                else if (Request.QueryString["uplCtrlID"] == AjaxFileUploadTwo.ClientID)
                {
	  /** different path assignment for each uploader **/
                    path = @"C:\Temp\FileUploaderTwo\";
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    AjaxFileUploadOne.SaveAs(path + e.FileName);              
                }
                else if (Request.QueryString["uplCtrlID"] == AjaxFileUploadThree.ClientID)
                {
                    /** different path assignment for each uploader **/
                    path = @"C:\Temp\FileUploaderThree\";
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    AjaxFileUploadOne.SaveAs(path + e.FileName);                                    
                }
            }            
        }
        catch (Exception ex)
        {
        }
    }

    if (FileUploadControl.PostedFile != null && FileUploadControl.PostedFile.ContentLength > 0)
    {
    	var allowedExtensions = new string[] { "doc", "docx", "pdf" };
    	var extension = Path.GetExtension(FileUploadControl.PostedFile.FileName).ToLower().Replace(".", "");
    	
    	if (FileUploadControl.FileContent.Length < 100000 && allowedExtensions.Contains(extension))
    	{
    		string filename = 
    		Path.GetFileName(FileUploadControl.PostedFile.FileName);
    		string folder = Server.MapPath("~/Docfiles/");
    		Directory.CreateDirectory(folder);
    		FileUploadControl.PostedFile.SaveAs(Path.Combine(folder, filename));
    		
    		try
    		{
    			cc.upload1(Txt_docde.Value, txt_dname.Value, FileUploadControl.FileName, Convert.ToInt32(Docdrop.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue),  Convert.ToString(Session["Login2"]),Convert.ToInt32(Session["UserID"]));
    			StatusLabel.ForeColor = System.Drawing.Color.Green;
    			StatusLabel.Text = "Success";
    		}
    		catch
    		{
    			StatusLabel.ForeColor = System.Drawing.Color.Red;
    			Label2.Text = "Failed";
    		}
    	}
    	else
    	{
    		 StatusLabel.ForeColor = System.Drawing.Color.Red;
    		 Label2.Text = "File Size to big";
    	}
    }

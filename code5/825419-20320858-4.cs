    protected void Upload(object sender, EventArgs e)
    {
        int contentLength = avatarUpload.PostedFile.ContentLength;//You may need it for validation
        string contentType = avatarUpload.PostedFile.ContentType;//You may need it for validation
        string fileName = avatarUpload.PostedFile.FileName;
        avatarUpload.PostedFile.SaveAs(@"c:\test.tmp");//Or code to save in the DataBase.
    }

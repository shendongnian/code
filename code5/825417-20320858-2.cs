    protected void Upload(object sender, EventArgs e)
    {
        int contentLength = avatarUpload.PostedFile.ContentLength;
        string contentType = avatarUpload.PostedFile.ContentType;
        string fileName = avatarUpload.PostedFile.FileName;
        avatarUpload.PostedFile.SaveAs(@"c:\test.tmp");//Or code to save in the DataBase.
    }

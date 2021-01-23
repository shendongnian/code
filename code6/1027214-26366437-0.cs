    string strHeaderFileName;
    protected void multiFileUpload_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        // ...
        strHeaderFileName = e.File.FileName;
        // ...
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // can use strHeaderFileName
    }

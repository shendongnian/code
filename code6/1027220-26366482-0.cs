    class Page
    {
      private string strHeaderFileName;
     protected void multiFileUpload_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            // No Loop needed multiFileUpload_FileUploaded will be called for each file uploaded
            strHeaderFileName = e.File.FileName;
            // Use the filename as the Header Name
            var strHeaderName = strHeaderFileName.Replace(".jpg", "");
            // allow Underscore characters in FileName to become Spaces in the Display Name.
            strHeaderName = strHeaderName.Replace("_", " ");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // use the same strHeaderFileName value here?
           someFunctionUses(strHeaderFileName);
        }
    }

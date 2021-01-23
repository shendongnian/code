    if(fileUpload.HasFile)
    {
        var sizeLimit = 1024 * 1024; // Limit to a megabyte
        if (fileUpload.PostedFile.ContentLength > sizeLimit)
            lblError.Tet = "File is too large";
        else
        {
            using(StreamReader sr = new StreamReader(fileUpload.FileContent))
            {
                String fileContent = sr.ReadToEnd();
                String fileName = Path.GetFileName(fileUpload.FileName);   
                this.lblMessage.Text = (fileContent);
            }
        }
    }

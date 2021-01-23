    public override void btnFILEOPEN_Click(object sender, EventArgs args)
    {
        // Get the name of the file to be uploaded and 
        // the location where the file needs to be opened from
        // in my case it's a "../Data" folder within the IIS root folder.
        string fileName = this.AttachmentFilePath.Text;
        bool fileExists = System.IO.File.Exists((this.Page.Server.MapPath("..\\Data") + ("\\" + fileName)));
        if (fileExists)
        {
            // Set up file stream object.
            System.IO.FileStream fs;
            fs = new System.IO.FileStream((this.Page.Server.MapPath("..\\Data") + ("\\" + fileName)), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            string fullFileName = (this.Page.Server.MapPath("..\\Data") + ("\\" + fileName));
            try
            {
                // Read the contents of the file.
                int bufSize = ((int)(fs.Length));
                byte[] buf = new byte[bufSize];
                int bytesRead = fs.Read(buf, 0, bufSize);
                // Set up parameters for file download.
                this.Page.Response.Clear();
                this.Page.Response.ContentType = "application/octet-stream";
                this.Page.Response.AddHeader("Content-Disposition", ("attachment;filename=" + HttpUtility.UrlEncode(fileName)));
                
                // Download the file.
                this.Page.Response.OutputStream.Write(buf, 0, bytesRead);
                this.Page.Response.Flush();
            }
            catch (Exception ex)
            {
                // Report the error message to the user
                BaseClasses.Utils.MiscUtils.RegisterJScriptAlert(this, "UNIQUE_SCRIPTKEY", ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            this.Page.Response.Write("File cannot be found to download");
        }
    }

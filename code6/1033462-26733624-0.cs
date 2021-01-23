    /*...*/
    using (ZipFile zip = ZipFile.Read(ROBOT_INSTALL_SPECIAL))
            {
                zip.ExtractProgress += 
                   new EventHandler<ExtractProgressEventArgs>(zip_ExtractProgress);
                zip.ExtractAll(ROBOT0007, ExtractExistingFileAction.OverwriteSilently);
            }
    /*...*/
    void zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
    {
       progressBar1.Value = Convert.ToInt32(100 * e.BytesTransferred / e.TotalBytesToTransfer);
    }

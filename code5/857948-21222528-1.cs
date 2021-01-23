    private void UploadFile(string filename)
        {
            try
            {
                ArchiveServiceObj.ArchiveServiceSoapClient srv = new ArchiveServiceObj.ArchiveServiceSoapClient();
                MemoryStream stream = new MemoryStream();
                picscannedimage.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                string sTmp = srv.UploadFile(pic, filename + ".jpg");
                MessageBox.Show("File Upload Status: " + sTmp, "File Upload");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Upload Error");
            }
        }
     

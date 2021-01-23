    private void UploadImage(string filepath)
    {
        using(WebClient uploader = new WebClient())
        {
            try
            {
                uploader.UploadFile(new Uri("http://uploads.im/api?upload"), filepath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occured :(\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

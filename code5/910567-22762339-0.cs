    protected void ButtonDeserialize_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                filename = Path.GetFileName(FileUploadControl.FileName);
                pathname = Path.GetDirectoryName(filename);
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }

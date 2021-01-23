    protected void uploadFiles_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in FileUpload2.PostedFiles)
                {
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/MyPath/"),
                    uploadedFile.FileName));
                    listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                }
            }
        }

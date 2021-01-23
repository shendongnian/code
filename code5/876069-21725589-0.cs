    protected void uploadFile_Click(object sender, EventArgs e)
    {
       if (UploadImages.HasFiles)
       {
           foreach (HttpPostedFile uploadedFile in UploadImages.PostedFiles)
           {
               uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"),
               uploadedFile.FileName));
               listofuploadedfiles.Text += String.Format("{0}<br/>", uploadedFile.FileName);
           }
       }
}
    

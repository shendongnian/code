    protected void btnChangeUserPic2_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = Server.MapPath("~/Upload/");                            
            HttpPostedFile File = userPicFileUpload.PostedFile;
            string fileExtn = Path.GetExtension(File.FileName).ToLower();
            string filename = System.IO.Path.GetFileName(File.FileName);               
            File.SaveAs(filename);
            lblStatus.Visible = true;
            lblStatus.Text = "Profile picture changed successfully !!";
            profilepic.ImageUrl=filePath+filename;
        }
        catch (Exception ex)
        {               
        }
    }

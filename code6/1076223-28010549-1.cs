      public partial class VideoFileUpload : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            protected void UploadVideoAndImage(object sender, DirectEventArgs e)
            {
                string videoUrl = "";
                string imageUrl = "";
              
                const string folderName = "clientname";
                if (fufPhoto.HasFile)
                {
                    string FileName = System.IO.Path.GetFileName(fufPhoto.PostedFile.FileName);
                    string FilePath = "Uploads/" + folderName + "/" + FileName;
                    bool exists = System.IO.Directory.Exists(Server.MapPath("~/Uploads/" + folderName + "/"));
                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/" + folderName + "/"));
                    }
                    fufPhoto.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + folderName + "/" + FileName));
                    imageUrl = FilePath;
                }
                if (fufVideo.HasFile)
                {
                    string FileName = System.IO.Path.GetFileName(fufVideo.PostedFile.FileName);
                    string FilePath = "Uploads/" + folderName + "/" + FileName;
                    bool exists = System.IO.Directory.Exists(Server.MapPath("~/Uploads/" + folderName + "/"));
                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/" + folderName + "/"));
                    }
                    fufVideo.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + folderName + "/" + FileName));
                    videoUrl = FilePath;
                }
                
            }
        }

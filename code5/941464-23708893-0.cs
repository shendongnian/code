    // code to upload files
    HttpFileCollection fileCollection = Request.Files;
    if (fileCollection.Count != 0)
    {
        string filename = string.Empty;
        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile file = fileCollection[i];
            filename = Path.GetFileName(file.FileName);
            if (file.ContentLength > 0)
            {
                string strFilePath = "~/Uploads/";
                System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(MapPath(strFilePath));
                if (!DI.Exists)
                {
                    System.IO.Directory.CreateDirectory(MapPath(strFilePath));
                }
                strFilePath = strFilePath + filename;
                file.SaveAs(Server.MapPath(strFilePath));
                // save the filepath variable to your database
            }
        }
    }

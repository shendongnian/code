    public static void UploadFile(ClientContext context, string folderUrl, string uploadFilePath)
    {
        using (var fs = new FileStream(uploadFilePath, FileMode.Open))
        {
            var fileName = Path.GetFileName(uploadFilePath);
            var fileUrl = String.Format("{0}/{1}", folderUrl, fileName);
            Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
        }
    }

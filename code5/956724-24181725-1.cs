    public static void UploadFile(Web web,string serverRelativeUrl, string filePath)
    {
         using (var fs = new FileStream(filePath, FileMode.Open))
         {
            var fi = new FileInfo(filePath);
            var fileUrl =  String.Format("{0}/{1}", serverRelativeUrl, fi.Name);
            Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, fileUrl, fs, true);
         }
    } 

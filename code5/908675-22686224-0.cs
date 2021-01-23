    [WebMethod]
    public static string buttonclickImage(string pageNo)
    {
    
           int iPageNo = 0;
           if (pageNo != string.Empty && pageNo != "undefined")
              iPageNo = Int32.Parse(pageNo);
    
           FileTransfer.FileTransferClient fileTranz = new FileTransfer.FileTransferClient();
           //note the change here. no double quotes.
           FileDto file = fileTranz.GetTifftoJPEG(concatenatedStr, iPageNo, "gmasdll"); 
    
    
           var fileData = Convert.ToBase64String(file.Content);//throws error
           return fileData;
     }

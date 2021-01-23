    string fileToMove = "ftp://127.0.0.1/Folder1/File.csv";
    string renamedFile = "FileRenamed.old";
    
    FtpWebRequest ftpRenameFile = (FtpWebRequest)WebRequest.Create(fileToMove);
    ftpRenameFile.Credentials = new NetworkCredential(username, password);
    
    ftpRenameFile.Method = WebRequestMethods.Ftp.Rename;
    ftpRenameFile.RenameTo = renamedFile;   
    ftpRenameFile.UseBinary = false;
    ftpRenameFile.UsePassive = true; 
     
    FtpWebResponse renameResponse = (FtpWebResponse)ftpRenameFile.GetResponse();

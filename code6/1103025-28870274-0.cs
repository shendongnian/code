    public void ListChildren(IFolder folder)
    {
        FtpClient ftpClient = new FtpClient
        {
            Host = new Uri("ftp://127.0.0.1/").Host,
            Credentials = new NetworkCredential("UserLocal", "1234");
        };
        ftpClient.SetWorkingDirectory(folder.FullName);
        ListChildren(ftpClient, ftpClient.GetWorkingDirectory());
    }
    private void ListChildren(FtpClient ftpClient, IFolder folder)
    {
        foreach (FtpListItem item in folder, FtpListOption.Modify | FtpListOption.Size))
        {
            switch (item.Type)
            {
                case FtpFileSystemObjectType.Directory:
                    FtpFolder ftpSubFolder = new FtpFolder(item);
                    folder.Folders.Add(ftpSubFolder);
                    ListChildren(ftpSubFolder);
                    break;
                case FtpFileSystemObjectType.File:
                    folder.Files.Add(new FtpFile { Item = item });
                    break;
            }
        }
    }

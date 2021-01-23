    // returns true if the file had downloaded
    public static bool DownloadSftpFile(string[] hosts, int port, string username, string password, string remotePathAndFile, string localPath)
    {
        foreach (var host in hosts)
        {
            try
            {
                DownloadSftpFile(host, port, username, password, remotePathAndFile, localPath);
                return true;
            }
            catch(SshConnectionException exception)
            {
                // log
            }
            catch(SocketExcpetion exception)
            {
                // log
            }
        }
        return false;
    }
    private static void DownloadSftpFile(string host, int port, string username, string password, string remotePathAndFile, string localPath)
    {
        using (var sftp = new Sftp(host, username, password))
        {
            sftp.Connect(port);
            sftp.Get(remotePathAndFile, localPath);
        }
    }

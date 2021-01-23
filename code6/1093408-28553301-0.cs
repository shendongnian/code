    // This needs to be an instance field instead of local variable, so that
    // the object's `Abort()` method can be called elsewhere
    private FtpWebRequest ftp;
    public async Task DownloadFTPAsync(CancellationToken cancelToken,
       string LocalDirectory, string RemoteFile, string Login, string Password)
    {
        try
        {
            ftp = (FtpWebRequest)FtpWebRequest.Create(RemoteFile);
            ftp.Credentials = new NetworkCredential(Login, Password);
            ftp.KeepAlive = false;
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp.UseBinary = true;
            // [PD]: I don't know what this method does or even what the name
            // means, but on the assumption that because it needs the login
            // and password information, it may be doing some longer network
            // I/O or something, I'm wrapping it in a task to ensure the calling
            // thread remains responsive.
            long pesoarchivo = await Task.Run(() => obtenertamano(RemoteFile, Login, Password));
            // This is invariant, so might as well calculate it here, rather
            // than over and over again in the stream I/O loop below
            int totalSize = (int)(pesoarchivo) / 1000;
            ftp.Proxy = null;
            ftp.EnableSsl = false;
            LocalDirectory = Path.Combine(LocalDirectory, Path.GetFileName(RemoteFile));
            using (FileStream fs = new FileStream(LocalDirectory, FileMode.Create,
                                        FileAccess.Write, FileShare.None))
            using (Stream strm = (await ftp.GetResponseAsync()).GetResponseStream())
            {
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                // Check for cancellation. This will throw an exception
                // if cancellation was requested; if you'd prefer, you can
                // check the cancelToken.IsCancellationRequested property
                // instead and just return, or whatever.
                cancelToken.ThrowIfCancellationRequested();
                while ((contentLen = await strm.ReadAsync(buff, 0, buff.Length)) > 0)
                {
                    await fs.WriteAsync(buff, 0, contentLen);
                    // Here, the calling thread (i.e. the UI thread) is executing
                    // the code so just update whatever progress indication
                    // you want directly.
                    label1.Text = ((fs.Position / 1000) * 100 / totalSize).ToString();
                    // Keep checking inside the loop
                    cancelToken.ThrowIfCancellationRequested();
                }
            }
        }
        finally
        {
            ftp = null;
        }
    }

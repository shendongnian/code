    public static async Task SelectRectangle(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath)
    {
        using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
    
                g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);
    
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(Properties.Settings.Default.ftphost + Properties.Settings.Default.ftppath + FilePath + "." + Properties.Settings.Default.extension_plain);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Properties.Settings.Default.ftpuser, Properties.Settings.Default.ftppassword);
                request.UseBinary = true;
    
                Stream rs = await request.GetRequestStreamAsync();
                bitmap.Save(rs, ImageFormat.Png);
            }
        }
    }

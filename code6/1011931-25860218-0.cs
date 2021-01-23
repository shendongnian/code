        private static void upzip(string url)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(url, "temp.zip");  
            //unzip
            ZipFile zf = null;
            try
            {
                zf = new ZipFile(File.OpenRead("temp.zip"));
                foreach (ZipEntry zipEntry in zf)
                {
                    string fileName = zipEntry.Name;
                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(zipEntry);
                    using (FileStream streamWriter = File.Create( fileName))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
 
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true;
                    zf.Close();
                }
            }
 
        }

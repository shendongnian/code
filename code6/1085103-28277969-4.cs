        public void DownloadFileAsync()
        {
            WebClient wc = new WebClient();
            Uri uri = new Uri(myURL);
            //Open Stream from URI
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCallback);
            wc.OpenReadAsync(uri);
        }
        private static void OpenReadCallback(Object sender, OpenReadCompletedEventArgs e)
        {
            Stream resStream = null;
            try
            {
                resStream = (Stream)e.Result;
                //Your decompression stream Gzip for example
                using (GZipStream compressionStream = new GZipStream(resStream, CompressionMode.Decompress))
                {
                    //write gzip stream to file
                    using (
                        FileStream outFile = new FileStream(@"c:\mytarget.somefile", FileMode.Create, FileAccess.Write,
                            FileShare.None))
                          compressionStream.CopyTo(outFile);
                }
            }
            finally
            {
                if (resStream != null)
                {
                    resStream.Close();
                }
            }
        }

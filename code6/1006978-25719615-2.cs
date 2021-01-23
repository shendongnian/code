        private void DoSincroFit()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            //Add headers to request
            request.Headers["Type"] = "sincrofit";
            request.Headers["Device"] = "1";
            request.Headers["Version"] = "0.000";
            request.Headers["Os"] = "WindowsPhone";
            request.Headers["Cache-Control"] = "no-cache";
            request.Headers["Pragma"] = "no-cache";
            request.BeginGetResponse(new AsyncCallback(playResponseAsync), request);
        }
        public async void playResponseAsync(IAsyncResult asyncResult)
        {
            //Declaration of variables
            HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;
            try
            {
                string fileName = "sincrofit.rar";
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
                {
                    byte[] buffer = new byte[1024];
                    var newZipFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                    using (var writeStream = await newZipFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        using (var outputStream = writeStream.GetOutputStreamAt(0))
                        {
                            using (var dataWriter = new DataWriter(outputStream))
                            {
                                using (Stream input = webResponse.GetResponseStream())
                                {
                                    var totalSize = 0;
                                    for (int size = input.Read(buffer, 0, buffer.Length); size > 0; size = input.Read(buffer, 0, buffer.Length))
                                    {
                                        dataWriter.WriteBytes(buffer);
                                        totalSize += size;    //get the progress of download
                                    }
                                    await dataWriter.StoreAsync();
                                    await outputStream.FlushAsync();
                                    dataWriter.DetachStream();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                
            }

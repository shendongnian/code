        private void DoSincroFit()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            //Add headers to request
            request.Headers["Type"] = "sincrofit";
            request.Headers["Device"] = "1";
            request.Headers["Version"] = "0.000";
            request.Headers["Os"] = "WindowsPhone";
            //Windows Cache Problems
            request.Headers["Cache-Control"] = "no-cache";
            request.Headers["Pragma"] = "no-cache";
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            request.BeginGetResponse(new AsyncCallback(playResponseAsync), request);
        }
        public async void playResponseAsync(IAsyncResult asyncResult)
        {
            //Declaration of variables
            HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;
            try
            {
                //For download file  with stream
                string fileName = "sincrofit.rar";
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
                {
                    byte[] buffer = new byte[1];
                    //For acces Local folder of phone device
                    var newZipFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                    //Progress bar and their update
                    using (var writeStream = await newZipFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        using (var outputStream = writeStream.GetOutputStreamAt(0))
                        {
                            using (var dataWriter = new DataWriter(outputStream))
                            {
                                using (Stream input = webResponse.GetResponseStream())
                                {
                                    var totalSize = 0;
                                    int read;
                                    uint zeroUint = Convert.ToUInt32(0);
                                    uint readUint;
                                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        totalSize += read; 
                                        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                                        {
                                            //Declaration of variables
                                            pBar.Value = totalSize * 100 / sizeFit;
                                        });
                                        readUint = Convert.ToUInt32(read);
                                        IBuffer ibuffer = buffer.AsBuffer();
                                        dataWriter.WriteBuffer(ibuffer, zeroUint, readUint);
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
                //For control errors stopped progress bar
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    //Declaration of variables
                    SMethods.Message_Dialog("Download has stopped!", "Error");
                });
            }
        }

        private CoreDispatcher dispatcher;
        private void DoSincroFit()
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            //Add headers to request
            request.Headers["Type"] = "sincrofit";
            request.Headers["Device"] = "1";
            request.Headers["Version"] = "0.000";
            request.Headers["Os"] = "WindowsPhone";
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
                //http://social.msdn.microsoft.com/Forums/windowsapps/en-US/de96a61c-e089-4595-8349-612be5d23ee6/download-file-with-httpwebrequest?forum=winappswithcsharp
                string fileName = "sincrofit.rar";
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult))
                {
                    byte[] buffer = new byte[1024];
                    //For acces Local folder of phone device
                    //http://social.msdn.microsoft.com/Forums/windowsapps/en-US/ec99721c-6565-4ce9-b6cc-218f2265f9c7/what-is-the-uri-of-an-isolatedstorage-file?forum=wpdevelop
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
                                        dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                                        {
                                            //Declaration of variables
                                            pBar.Value = sizeFit / totalSize * 100;
                                        });
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
                dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    //Declaration of variables
                    SMethods.Message_Dialog("Download has stopped!", "Error");
                });
            }
        }

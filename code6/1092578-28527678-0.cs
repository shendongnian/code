    public async Task<bool> download()
    {
        HttpWebRequest request = HttpWebRequest.CreateHttp(url);
        HttpWebResponse webResponse = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, request);
   
        try
        {
            using (webResponse)
            {
                byte[] buffer = new byte[1024];
    
                using (var writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
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
                Debug.WriteLine("Finished");
            }
        }
        catch
        {
            return false;
        }
    }
    return true;
    }

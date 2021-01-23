    HttpClient client = new HttpClient();
    foreach (Doodle d in doodleslist)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, d.url.Replace("//", "http://"));
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            //write to file.
            filename = d.name.Replace(@"/", "-");
            var imgFile = await folder.CreateFileAsync(filename + ".jpg", CreationCollisionOption.ReplaceExisting);
            var fs = await imgFile.OpenAsync(FileAccessMode.ReadWrite);
             using (var outStream = fs.GetOutputStreamAt(0))
                        {
                            using (var dataWriter = new Windows.Storage.Streams.DataWriter(outStream))
                            {
                                dataWriter.WriteBytes(await response.Content.ReadAsByteArrayAsync());
                                await dataWriter.StoreAsync();
                                dataWriter.DetachStream();
                                await fs.FlushAsync();
                                dataWriter.Dispose();
                                fs.Dispose();
                            }
                        }
    }

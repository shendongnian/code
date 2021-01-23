    StroageFile file = // Get file here..
    byte[] fileBytes = null;
    using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (DataReader reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }
    var httpClient = new HttpClient();
    var byteArrayContent = new ByteArrayContent(fileBytes);
    httpClient.PostAsync(address, fileBytes);

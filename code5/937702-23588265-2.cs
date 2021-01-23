        var result = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
        foreach (var item in result.Contents)
        {
            using (var fileStream = await item.ReadAsStreamAsync())
            {
                await fileStorageService.Save(@"large/Sam.jpg", fileStream);
            }
            item.Dispose();
        }

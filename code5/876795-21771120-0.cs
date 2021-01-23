    private async Task<IInputStream> GetContent(string path)
        {
            try
            {
                path = path.TrimStart('/');
                var file = await StorageApplicationPermissions.FutureAccessList.GetFileAsyn(App.token);
                
                var archive = new ZipArchive(await file.OpenStreamForReadAsync(),ZipArchiveMode.Read);
                var entry = archive.GetEntry(path);
                var contents = new byte[entry.Length];
                var entryStream = entry.Open();
                var tempFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("temp.xhtml",CreationCollisionOption.ReplaceExisting);
                var decompressedStream = await tempFile.OpenStreamForWriteAsync();
                await entryStream.CopyToAsync(decompressedStream, (int)entry.Length);
                await decompressedStream.FlushAsync();
                decompressedStream.Dispose();
                var returnFile = await ApplicationData.Current.LocalFolder.GetFileAsync("temp.xhtml");
                var returnStream = await returnFile.OpenSequentialReadAsync();
                return returnStream;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

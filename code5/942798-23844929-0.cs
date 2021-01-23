      public async void zipit(StorageFile zipFile, StorageFile file)
        {
         using (var zipToOpen = await zipFile.OpenStreamForWriteAsync())
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry(file.Name);
                    using (Stream writer = readmeEntry.Open())
                    {
                        //writer.WriteLine("Information about this package.");
                        //writer.WriteLine("========================");
                        byte[] data = await GetByteFromFile(file);
                        writer.Write(data, 0, data.Length);
                    }
                }
            }
        } 

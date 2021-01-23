    async public static Task WriteAllTextAsync(this StorageFile storageFile, string content) 
            { 
                var inputStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite); 
                var writeStream = inputStream.GetOutputStreamAt(0); 
                DataWriter writer = new DataWriter(writeStream); 
                writer.WriteString(content); 
                await writer.StoreAsync(); 
                await writeStream.FlushAsync(); 
            }

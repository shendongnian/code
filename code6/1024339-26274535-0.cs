        public async Task SaveStreamToFile(Stream stream, string filePath, IProgress<long> progress )
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(Path.GetDirectoryName(filePath));
            var fileName = Path.GetFileName(filePath);
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            var istream = stream.AsInputStream();
            using (var reader = new DataReader(istream))
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                    {
                        using (DataWriter writer = new DataWriter(outputStream))
                        {
                            long writtenBytes = 0;
                            const int bufferSize = 8192;
                            uint loadedBytes = 0;
                            while ((loadedBytes = (await reader.LoadAsync(bufferSize))) > 0) //!!!
                            {
                                IBuffer buffer = reader.ReadBuffer(loadedBytes);
                                writer.WriteBuffer(buffer);
                                uint tmpWritten = await writer.StoreAsync(); //!!!
                                writtenBytes += tmpWritten;
                                progress.Report(writtenBytes);
                            }
                        }
                    }
                }
            }
        }    

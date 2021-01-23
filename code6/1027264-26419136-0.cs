        public static async Task<T> DeserializeFromBinary<T>(string filename, StorageFolder storageFolder)
        {
            try
            {
                
                var file = await storageFolder.GetFileAsync(filename);
                if (file != null)
                {
                    var stream = await file.OpenStreamForReadAsync();
                    T content = Serializer.Deserialize<T>(stream);
                    return content;
                }
            }
            catch (NullReferenceException nullException)
            {
                logger.LogError("Exception happened while de-serializing input object, Error: " + nullException.Message);
            }
            catch (FileNotFoundException fileNotFound)
            {
                logger.LogError("Exception happened while de-serializing input object, Error: " + fileNotFound.Message);
            }
            catch (Exception e)
            {
                logger.LogError("Exception happened while de-serializing input object, Error: " + e.Message, e.ToString());
            }
            return default(T);
        }
        public static async Task<bool> SerializeIntoBinary<T>(string fileName, StorageFolder destinationFolder, Content content)
        {
            bool shouldRetry = true;
            while (shouldRetry)
            {
                try
                {
                    
                    StorageFile file = await destinationFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                    using (var stream = await file.OpenStreamForWriteAsync())
                    {
                        Serializer.Serialize(stream, content);
                        shouldRetry = false;
                        return true;
                    }
                }
                catch (UnauthorizedAccessException unAuthorizedAccess)
                {
                    logger.LogError("UnauthorizedAccessException happened while serializing input object, will wait for 5 seconds, Error: " + unAuthorizedAccess.Message);
                    shouldRetry = true;
                }
                catch (NullReferenceException nullException)
                {
                    shouldRetry = false;
                    logger.LogError("Exception happened while serializing input object, Error: " + nullException.Message);
                }
                catch (Exception e)
                {
                    shouldRetry = false;
                    logger.LogError("Exception happened while serializing input object, Error: " + e.Message, e.ToString());
                }
                if (shouldRetry)
                    await Task.Delay(5000);
            }
            return false;
        }

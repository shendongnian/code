    public static async Task<bool> SerializeIntoJson<T>(string fileName, StorageFolder destinationFolder, Content content)
        {
            try
            {
                StorageFile file = await destinationFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    StreamWriter writer = new StreamWriter(stream);
                    JsonTextWriter jsonWriter = new JsonTextWriter(writer);
                    JsonSerializer ser = new JsonSerializer();
                    ser.Formatting = Newtonsoft.Json.Formatting.Indented;
                    ser.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    ser.TypeNameHandling = TypeNameHandling.All;
                    ser.Error += ReportJsonErrors;
                    ser.Serialize(jsonWriter, content);
                    jsonWriter.Flush();
                    
                }
                return true;
            }
            catch (NullReferenceException nullException)
            {
                logger.LogError("Exception happened while serializing input object, Error: " + nullException.Message);
                return false;
            }
            catch (Exception e)
            {
                logger.LogError("Exception happened while serializing input object, Error: " + e.Message, e.ToString());
                return false;
            }
        }

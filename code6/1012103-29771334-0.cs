        public static async Task<IEnumerable<KeyValuePair<string, object>>> GetIsolatedStorageValuesAsync()
        {
            try
            {
                using (var fileStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("__ApplicationSettings"))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        var line = streamReader.ReadLine() ?? string.Empty;
                        var knownTypes = line.Split('\0')
                            .Where(x => !string.IsNullOrEmpty(x))
                            .Select(Type.GetType)
                            .ToArray();
                        fileStream.Position = line.Length + Environment.NewLine.Length;
                        var serializer = new DataContractSerializer(typeof (Dictionary<string, object>), knownTypes);
                        return (Dictionary<string, object>) serializer.ReadObject(fileStream);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // ignore the FileNotFoundException, unfortunately there is no File.Exists to prevent this
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new Dictionary<string, object>();
        }

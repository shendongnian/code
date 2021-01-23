        private const string DbBasePath = "MyApp.TestHelpers.TestDatabases.";    
        public static IAsyncOperation<IStorageFile> GetDbAsync(string dbName)
        {
            return Util.GetFileFromAssemblyResource(typeof(Data).GetTypeInfo().Assembly, DbBasePath + dbName, dbName, ApplicationData.Current.LocalFolder).AsAsyncOperation();
        }
        public static async Task<IStorageFile> GetFileFromAssemblyResource(Assembly ass, string resource, string filenameToCreate, IStorageFolder location)
        {
            IStorageFile file;
            // read for embedded resources
            using (var stream = ass.GetManifestResourceStream(resource))
            {
                var buf = new byte[stream.Length];
                // create file
                file = await location.CreateFileAsync(DateTime.Now.Ticks + filenameToCreate, CreationCollisionOption.ReplaceExisting);
                using (var memStream = new MemoryStream())
                {
                    int read;
                    // read bytes at a time from the embedded resource
                    while ((read = await stream.ReadAsync(buf, 0, buf.Length)) > 0)
                    {
                        // write from memory into buffer
                        await memStream.WriteAsync(buf, 0, read);
                        // write buffer to file
                        await FileIO.WriteBytesAsync(file, buf);
                    }
                }
            }
            return file;
        }

    public async Task Read(string fileName)
        {
            string text = "";
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            IStorageFile storageFile = await applicationFolder.GetFileAsync(fileName);
            IRandomAccessStream accessStream = await storageFile.OpenReadAsync();
            using (Stream stream = accessStream.AsStreamForRead((int)accessStream.Size))
            {
                byte[] content = new byte[stream.Length];
                await stream.ReadAsync(content, 0, (int)stream.Length);
                text = Encoding.UTF8.GetString(content, 0, content.Length);
            }
            XDocument loadedDataH = XDocument.Parse(text);
            var vPosting = from query in loadedDataH.Descendants("Row")
                           select new clssColPost(query);
            this.Clear();
            AddRange(vPosting);
           
        }
        public async Task Write(string fileName)
        {
            XElement xml = new XElement("Tabel",
                              from p in this
                              select p.Information);
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            IStorageFile storageFile = await applicationFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await storageFile.OpenStreamForWriteAsync())
            {
                byte[] content = Encoding.UTF8.GetBytes(xml.ToString());
                await stream.WriteAsync(content, 0, content.Length);
            }
        }

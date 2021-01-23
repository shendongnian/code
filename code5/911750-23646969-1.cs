    public class DocumentMigrator
    {
        private Document item;
        private String path;
        public DocumentMigrator(Documentitem, string path)
        {
            this.item = item;
            this.path = path;
        }
        public void MigrateToLatestVersion()
        {
            Migrate(Document.CURRENT_VERSION);
        }
        public void Migrate(int to)
        {
            Migrate(item.Version, to);
        }
        private void Migrate(int from, int to)
        {
            if (from < to)
            {
                while (item.Version < to)
                    Up(item.Version + 1);
            }
            else if (from > to)
            {
                while (item.Version < to)
                    Down(item.Version - 1);
            }
        }
        private void Down(int version)
        {
            throw new NotImplementedException();
        }
        private void Up(int version)
        {
            if (version == 2)
            {
                var stream = File.OpenRead(path);
                var serializer = new XmlSerializer(typeof(DocumentV1));
                var document = (DocumentV1)serializer.Deserialize(stream);
                this.item.RawImageString = document.ImageString;
            }
            else
            {
                throw new NotImplementedException();
            }
            this.item.Version = version;
        }
    }
    public class DocumentV1
    {
        public string ImageString { get; set; }
    }

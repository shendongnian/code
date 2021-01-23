    internal sealed class MediaFile
    {
        private readonly Lazy<UltraID3> _lazyFile;
        public MediaFile(string filePath)
        { 
            _lazyFile = new Lazy<UltraID3>(() =>
            {
                var file = new UltraID3();
                file.Read(filePath);
                return file;
            });
        }
        public string Title
        {
            get { return _lazyFile.Value.Title; }
        }
        // ...
    }

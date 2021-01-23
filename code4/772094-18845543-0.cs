    public class SimpleSqlFileNameProvider : ISqlFileNameProvider
    {
        private readonly string _filename;
        public SimpleSqlFileNameProvider(string filename)
        {
            _filename = filename;
        }
        public string SqlFilename
        {
            get { return _filename; }
        }
    }

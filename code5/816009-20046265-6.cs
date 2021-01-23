        public class LocalFile
        {
            public LocalFile(
                string fileName, 
                Func<string, string> fnUrlResolver
                )
            {
                FileName = fileName;
                _fnUrlResolver = fnUrlResolver;
            }
            private readonly Func<string, string> _fnUrlResolver;
            public string FileName { get; private set; }
            public string Url { get { return _fnUrlResolver(FileName); } }
        }

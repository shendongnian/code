    class StreamReaderDataProvider : IFactoryDataSourceProvider<string> {
        public IList<string> GetData() {
            using (var streamReader = new StreamReader( ... )) {
                return streamReader.ReadAllLines(); // etc.
            }
        }
    }
    var list = factory.Create(new StreamReaderDataSourceProvider());

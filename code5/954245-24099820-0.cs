    public class ImportProvider
    {
        private readonly string _path;
        private readonly ObjectResolver _objectResolver;
        public ImportProvider(string path)
        {
            _path = path;
            _objectResolver = new ObjectResolver();
        }
        public void Import()
        {
            var filePaths = Directory.GetFiles(_path, "*.csv");
            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var className = fileName.Remove(fileName.Length-4);
                using (var reader = new CsvFileReader(filePath))
                {
                    var row = new CsvRow();
                    var repository = (DaoBase)_objectResolver.Resolve("DAL.Repository", className + "Dao");
                    while (reader.ReadRow(row))
                    {
                        var dtoInstance = (DtoBase)_objectResolver.Resolve("DAL.DTO", className + "Dto");
                        dtoInstance.FillInstance(row.ToArray());
                        repository.Save(dtoInstance);
                    }
                }
            }
        }
    }

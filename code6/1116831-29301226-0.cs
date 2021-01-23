    class YourClass<T>{
        private static object GetCSVRecords(string path)
        {
            using (var txtReader = new StreamReader(path))
            {
                var csv = new CsvReader(txtReader);
                var recordList = csv.GetRecords<T>();
                return recordList;
            }
        }
    }

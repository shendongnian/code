         [DelimitedRecord(",")]
        public class YourTypeForCSV
        {
            public string Field1;
            public int Field2;
        }
        void UploadFile(string filename, System.IO.Stream fileContent)
        {
            FileHelperEngine<YourTypeForCSV> engine = new FileHelperEngine<YourTypeForCSV>();
            YourTypeForCSV[] records = engine.ReadStream(new StreamReader(fileContent));
            // .. do whatever you need
        }

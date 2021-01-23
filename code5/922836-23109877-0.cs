    using (MemoryStream stream = new MemoryStream(_fileContent)) //file content can be file as byte array
                {
                    TextReader reader = new StreamReader(stream);
    string path = "C:\\Sample.csv";
                    CsvEngine csvEngine = new CsvEngine("Model", ',', path);
                    var dataTable = csvEngine.ReadStreamAsDT(reader);
    //Do whatever with dataTable
    
    }

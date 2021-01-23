    [Obsolete]
    interface IFileReader {...}
  
    class MySuperReader : IFileReader, IExcelFileReader, IExcelFileReader
    {
       void ReadExcelFile(string filePath) {...}
       void ReadXMLFile(string filePath) {...}
       void WriteExcelFile() {...}
       void WriteXMLFile() {...}
    }

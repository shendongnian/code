    interface IFileReader: IExcelFileReader, IXMLFileReader
    {
    }
    interface IExcelFileReader
    {
        void ReadExcelFile(string filePath);
        void WriteExcelFile();
    }
    
    interface IXMLFileReader
    {
        void ReadXMLFile(string filePath);
        void WriteXMLFile();
    }

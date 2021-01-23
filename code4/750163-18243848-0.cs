    private static void MoveSuccessRecords<T>(List<T> thisList, string VUEFileName, string folderArchive, string folderError)
    {
        StreamWriter successWriter = new StreamWriter(folderArchive + VUEFileName.Replace(extension, "_COMPLETE" + extension), true);
        CsvWriter successCSV = new CsvWriter(successWriter);
    
        successCSV.WriteHeader<T>();
    
        foreach (var item in thisList)
        {
            successCSV.WriteRecord(item);
        }
    
        successCSV.Dispose();
        successWriter.Dispose();
        successWriter.Close();
    }

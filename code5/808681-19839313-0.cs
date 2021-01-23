    static List<FileContent> GetFileContents(List<string> paths)
    {
        var resultList = new List<FileContent>();
        foreach (var path in paths)
        {
              if (CanReadFile(path){
                    resultList.Add(new FileContent(path, buffer));
              }
        return resultList;
    }
    static bool CanReadFile(string Path){
         try{
             using (FileStream stream = File.Open(path, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    int fileLength = (int)stream.Length;
                    byte[] buffer = new byte[fileLength];
                    reader.Read(buffer, 0, fileLength);
                }
         }catch(Exception){ //I do not care what when wrong, error when reading from file
             return false;
         }
         return true;
    }

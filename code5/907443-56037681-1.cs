    public void deleteFile(string filename){
        String filepath= Path.Combine(_he.WebRootPath,"images", filename);
        if (System.IO.File.Exists(prevFilePath))
            {
                 System.IO.File.Delete(prevFilePath);
            }
    }

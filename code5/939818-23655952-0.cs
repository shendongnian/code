    public static void DeleteFileContaining(string targetDirectory, string wildcard)
    {
        string searchPattern = string.Format("*{0}*", wildcard);
        var filesToDelete = Directory.EnumerateFiles(targetDirectory, searchPattern);
        foreach (var fileToDelete in filesToDelete)
        {
            try{
                File.Delete(fileToDelete);
            }catch(Exception ex){
                // log this...
            }
        }
    }

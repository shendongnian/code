    public static void DeleteFileContaining(string targetDirectory, string wildcard){
            string[] fileEntries = Directory.GetFiles(targetDirectory, wildcard);//something like *.jpg
        
            // delete all matching files. 
            foreach (string f in fileEntries)
            {
                File.Delete(f);
            }
    }

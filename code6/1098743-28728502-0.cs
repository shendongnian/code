    public void cascade(string path)
    {
        String[] childFiles = Directory.GetFiles(path);
        if(childFiles.lenght > 0)
        {
            String[] childFolders = Directory.GetDirectories(path); 
            ChangeFileName(childFiles); //iterate and change each fileName
            for (int p = 0; p < childFolders.Length; p++)
            {
                cascade(childFolders[p]);
            }
        }
    }

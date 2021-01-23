    public void cascade(string path)
        {
            if(IsDirectoryEmpty(path) == true) 
            { }
            else
            {
                String[] childFolders = Directory.GetDirectories(path);
                String[] childFiles = Directory.GetFiles(path);
                ChangeFileName(path);
                
                for (int p = 0; p < childFolders.Length; p++)
                {
                    cascade(childFolders[p]);
                }
            }
        }

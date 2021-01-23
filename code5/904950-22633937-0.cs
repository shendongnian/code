    DirectoryInfo dir = new DirectoryInfo(folderPath);
    DeleteFolderIfEmpty(dir);
    public void DeleteFolderIfEmpty(DirectoryInfo dir){
       if(dir.EnumerateFiles().Any() || dir.EnumerateDirectories().Any())
            return;
       DirectoryInfo parent = dir.Parent;
       dir.Delete();
       // Climb up to the parent
       DeleteFolderIfEmpty(parent);
    }

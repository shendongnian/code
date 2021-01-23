    public static void MoveFilesToMain(string sourceDirName, string destDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
    
            FileInfo[] files = dir.GetFiles();
            if (files.Length == 0 && dirs.Length == 0)
            {
              Directory.Delete(sourceDirName, false);
              return;
            }
            foreach (FileInfo file in files)
            {          
                File.Move(Path.Combine(sourceDirName, file.Name), Path.Combine(destDirName, file.Name));
            }
    
            foreach (DirectoryInfo subdir in dirs)
            {
              MoveFilesToMain(subdir.FullName, destDirName)
            }
        }

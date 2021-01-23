        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                    Filename = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, Filename);
                    string path = @"C:/MyCopyFile/UserFiles/Images/croppedAvatar/";
                    FileInfo file = new FileInfo(path);
                    file.Directory.Create();
                    string folderStructurePath = @"C:/MyCopyFile/UserFiles/Images/croppedAvatar/" + Filename;
                    System.IO.File.Copy(sourceFile, folderStructurePath, true);
            }
        }

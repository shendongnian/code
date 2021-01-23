    public static void AddToZip(string fileToAdd, string directory)
        {
            string entryName = fileToAdd.Replace(directory, string.Empty);//name of the file inside zip archive
            string tempDir = Path.Combine(directory, Path.GetFileNameWithoutExtension(entryName));
            if (Directory.Exists(tempDir)) DeleteDirector(tempDir);
            else Directory.CreateDirectory(tempDir);
            System.IO.File.Move(fileToAdd, Path.Combine(tempDir, entryName));//as the CreateFromDirectoy add all the file from the directory provided, we are moving our file to temp dir.
            string archiveName = entryName.Replace(Path.GetExtension(entryName), ".zip"); //name of the zip file.
            ZipFile.CreateFromDirectory(tempDir, Path.Combine(directory, archiveName));
            DeleteDirector(tempDir);
        }
        private static void DeleteDirector(string deletedir)
        {
            foreach (string file in Directory.GetFiles(deletedir))
            {
                System.IO.File.Delete(file);
            }
            Directory.Delete(deletedir);
        }

      string destPath = Path.Combine(filepath, "FileHolder");
      foreach (string file in AllDeskTopFiles)
      {
            string fileToMove = Path.GetFileName(file).ToLower();
            if (fileToMove != "test.txt")
            {
                string destFile = Path.Combine(destPath, fileToMove);
                if (!File.Exists(destFile))
                    File.Move(file, destFile);
            }
       }

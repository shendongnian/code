            try
            {
                if (FilePath == "")
                {
                    MessageBox.Show("Please Browse for and select a file");
                }
                else
                {
                    if (activedrawing == null)
                    {
                        MessageBox.Show("No Drawing Found");
                    }
                    else
                    {
                        string fileName = "InsertImage"+ FileName + ".PNG";
                        string sourcePath = FilePath;
                        string targetPath = info.ModelPath;
                        string sourceFile = System.IO.Path.Combine(sourcePath);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        if (!System.IO.Directory.Exists(targetPath))
                        {
                            System.IO.Directory.CreateDirectory(targetPath);
                        }
                        System.IO.File.Copy(sourceFile, destFile, true);

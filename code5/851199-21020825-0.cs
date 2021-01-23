     if (name.Contains(d))
                    {
                        string fileName = name;
                        string sourceFile = System.IO.Path.Combine(sourcePath.ToString(), fileName);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        File.Copy(sourceFile, destFile, true);
                    }

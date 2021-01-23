    static void Main(string[] args)
        {
            
           string pathToDirctory = @"C:\\";
           string baseDirectory = pathToDirctory;
            
           string path = SearchAllFolders(pathToDirctory,"Test");
            
            
        }
        private static string SearchAllFolders(string path, string search)
        {
            string folderPath = string.Empty;
            try
            {
                if ((File.GetAttributes(path) & FileAttributes.ReparsePoint)
                    != FileAttributes.ReparsePoint)
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        if (folder.Contains("RECYCLE.BIN"))
                        {
                            continue;
                        }
                        string p = Path.GetFileName(folder);
                        if ( p.Equals(search))
                        {
                            return folder;
                        }
                        else
                        {
                            string f = SearchAllFolders(folder ,search);
                            if (f != null)
                            {
                                return f;
                            }
                        }
                        
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            return null;
        }

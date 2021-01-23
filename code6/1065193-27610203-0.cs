    #region Delete_Illegal_Items
        public static void RemoveIllegalItems()
        {
            Console.Clear();
            DirectoryInfo Libraries = new DirectoryInfo(Library.DestinationMain);
            try
            {
                foreach (var Lib in Libraries.GetDirectories())
                {
                    Console.WriteLine("Working On {0}.", Lib.Name);
                    Parallel.Invoke(
                            () =>
                            {
                                RemoveBadFiles(Lib);
                            },
                            () =>
                            {
                                DeleteEmptyFolders(Lib);
                            }
                        );
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There Was An Unusual Error During Initialization Of Library Correction:\n{0}", e.InnerException.ToString());
            }
        }
        private static string[] BadFiles = { 
                                            @".hta",
                                            @".exe",
                                            @".lnk",
                                            @".tmp",
                                            @".config",
                                            @".ashx",
                                            @".hta.",
                                            @".hta::$DATA",
                                            @".zip",
                                            @".asmx",
                                            @".json",
                                            @".soap",
                                            @".svc",
                                            @".xamlx",
                                            @".msi",
                                            @".ops",
                                            @".pif",
                                            @".shtm",
                                            @".shtml",
                                            @"smt",
                                            @".vb",
                                            @".vbe",
                                            @".vbs",
                                            @".ds_store",
                                            @"ds_store",
                                            @"._.Trashes",
                                            @".Trashes",
                                            @".db",
                                            @".dat",
                                            @".sxw",
                                            @".ini",
                                            @".tif",
                                            @".tiff"
                                          };
        private static void RemoveBadFiles(DirectoryInfo directory)
        {
            DirectoryInfo[] dirs = null;
            FileInfo[] files = null;
            if (directory != null)
            {
                try
                {
                    files = directory.GetFiles();
                }
                catch (IOException) { }
            }
            try
            {
                dirs = directory.GetDirectories();
            }
            catch (IOException) { }
            catch (Exception e)
            {
                Console.WriteLine("\nError During Enumeration Of Items To Delete:\n{0}", e.Message);
            }
            if (files != null)
            {
                foreach (var file in files)
                {
                    try
                    {
                        if (file.IsReadOnly)
                        {
                            file.IsReadOnly = false;
                        }
                        if (BadFiles.Contains(Path.GetExtension(file.FullName)) || BadFiles.Contains(file.Name))
                        {
                            File.Delete(file.FullName);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nError During Removal Or Illegal Files:\n" + e.Message);
                    }
                }
            }
            
            if (dirs != null)
            {
                foreach (var dir in dirs)
                {
                    switch (dir.Name)
                    {
                        case ".TemporaryItems":
                            {
                                try
                                {
                                    Directory.Delete(dir.FullName);
                                }
                                catch { }
                                break;
                            }
                        case "TemporaryItems":
                            {
                                try
                                {
                                    Directory.Delete(dir.FullName);
                                }
                                catch { }
                                break;
                            }
                        case "AI_RecycleBin":
                            {
                                try
                                {
                                    Directory.Delete(dir.FullName);
                                }
                                catch { }
                                break;
                            }
                        case ".ToRemove":
                            {
                                try
                                {
                                    Directory.Delete(dir.FullName);
                                }
                                catch { }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    RemoveBadFiles(dir);
                }
            }
        }
        
        private static void DeleteEmptyFolders(DirectoryInfo directory)
        {
            Program Main = new Program();
            try
            {
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (var subDirectory in dirs)
                {
                    int sum = Library.CountLibrary(subDirectory.FullName);
                    if (sum == 0)
                    {
                        Directory.Delete(subDirectory.FullName);
                    }
                    DeleteEmptyFolders(subDirectory);
                }
            }
            catch { }
        }
        #endregion

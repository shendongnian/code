           string path = @"C:\temp\code\path1";
            string path2 = @"C:\temp\code\path2";
            string fileType = "*.h";
            DirectoryInfo d1 = new DirectoryInfo(path);
            DirectoryInfo d2 = new DirectoryInfo(path2);
            foreach (FileInfo f1 in d1.GetFiles(fileType, SearchOption.AllDirectories))
            {
                foreach (FileInfo f2 in d2.GetFiles(fileType, SearchOption.AllDirectories))
                {
                    if (f1.Name == f2.Name)
                    {
                        // you could also test the size before comparing actual data
                        if (f1.Length == f2.Length)
                        {
                            Console.WriteLine(string.Format("these files might be the same: {0}, {1}", f1.Name, f2.Name));
                        }
                        //lstProjectFiles.Items.Add(f1.Name).SubItems.Add(path);
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
            }

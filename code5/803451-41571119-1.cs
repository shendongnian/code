    public static void DirectoryCopy(string strSource, string Copy_dest)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(strSource);
    
            DirectoryInfo[] directories = dirInfo.GetDirectories();
    
            FileInfo[] files = dirInfo.GetFiles();
    
            foreach (DirectoryInfo tempdir in directories)
            {
                Console.WriteLine(strSource + "/" +tempdir);
    
                Directory.CreateDirectory(Copy_dest + "/" + tempdir.Name);// creating the Directory   
    
                var ext = System.IO.Path.GetExtension(tempdir.Name);
    
                if (System.IO.Path.HasExtension(ext))
                {
                    foreach (FileInfo tempfile in files)
                    {
                        tempfile.CopyTo(Path.Combine(strSource + "/" + tempfile.Name, Copy_dest + "/" + tempfile.Name));
    
                    }
                }
                DirectoryCopy(strSource + "/" + tempdir.Name, Copy_dest + "/" + tempdir.Name);
                
            }
    
            FileInfo[] files1 = dirInfo.GetFiles();
    
            foreach (FileInfo tempfile in files1)
            {
                tempfile.CopyTo(Path.Combine(Copy_dest, tempfile.Name));
                
            }
    }

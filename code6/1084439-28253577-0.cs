         string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments); 
            
           bool flag = System.IO.Directory.Exists(path);
            if (!flag)
            {
                System.IO.Directory.CreateDirectory(path);
            }

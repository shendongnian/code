      public void CopyFiles(string srcpath, List<string> sourcefiles, string destpath)
        {
            
            DirectoryInfo dsourceinfo = new DirectoryInfo(srcpath);
            if (!Directory.Exists(destpath))
            {
                Directory.CreateDirectory(destpath);
            }
            DirectoryInfo dtargetinfo = new DirectoryInfo(destpath);
            List<FileInfo> fileinfo = sourcefiles.Select(s => new FileInfo(s)).ToList();
            foreach (var item in fileinfo)
            {
                string destNewPath = CreateDirectoryStructure(item.Directory.FullName, destpath) + "\\" + item.Name;
                 File.Copy(item.FullName, destNewPath);
            }
        }
        public string CreateDirectoryStructure(string newPath, string destPath)
        {
            Queue<string> queue = new Queue<string>(newPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries));
            queue.Dequeue();
            while (queue.Count>0)
            {
                string dirName = queue.Dequeue();
                if(!new DirectoryInfo(destPath).GetDirectories().Any(a=>a.Name==dirName))
                {
                    Directory.CreateDirectory(destPath + "\\" + dirName);
                    destPath += "\\" + dirName;
                }
            }
            return destPath;
             
        }

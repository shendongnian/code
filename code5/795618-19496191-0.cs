        public List<FileInfo> getLastFiles(string path)
        {
            List<FileInfo> lastFiles = new List<FileInfo>();
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileinfo = new FileInfo(file);
                if ((DateTime.Now - fileinfo.LastWriteTime).TotalDays > 14)
                {
                    lastFiles.Add(fileinfo);
                }
            }
            return lastFiles;
        }

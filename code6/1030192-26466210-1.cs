        public void getDirectories(string dir)
        {
            // Create the Data Object
            SavedData data = new SavedData();
            data.path = dir;
            data.subDirectories = new List<SubDirectory>();
            foreach (string directory in Directory.GetDirectories(dir))
            {
                SubDirectory subDir = new SubDirectory();
                subDir.path = directory;
                subDir.subDirectories = getSubDir(directory);
                data.subDirectories.Add(subDir);
            }
            syncedDirectories.Add(data);
        }
        private List<SubDirectory> getSubDir(string dir)
        {
            List<SubDirectory> dataList = new List<SubDirectory>();
            SubDirectory subDir = new SubDirectory();
            foreach (string directory in Directory.GetDirectories(dir))
            {
                subDir.path = directory;
                subDir.subDirectories = new List<SubDirectory>();
                subDir.subDirectories = getSubDir(directory);
                dataList.Add(subDir);
            }
            return dataList;
        }

        public string GetParent(string path, string parentName)
        {
            var dir = new DirectoryInfo(path);
            if (dir.Parent == null)
            {
                return null;
            }
            if (dir.Parent.Name == parentName)
            {
                return dir.Parent.FullName;
            }
            return this.GetParent(dir.Parent.FullName, parentName);
        }

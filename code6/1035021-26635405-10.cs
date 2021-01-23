    class Dir
    {
        public string Name { get; set; }
        public Dictionary<string, Dir> Dirs { get; set; }
        public HashSet<string> Files { get; set; }
        public Dir(string name)
        {
            Name = name;
            Dirs = new Dictionary<string, Dir>();
            Files = new HashSet<string>();
        }
        public Dir FindOrCreate(string path)
        {
            int i = path.IndexOf('/');
            if (i > -1)
            {
                Dir dir = FindOrCreate(path.Substring(0, i));
                return dir.FindOrCreate(path.Substring(i + 1));
            }
            // if the path contains a "." it is a file, unless it is "." by itself
            if (path != "." && path.Contains("."))
            {
                Files.Add(path);
                return this;
            }
            Dir child;
            if (Dirs.ContainsKey(path))
            {
                child = Dirs[path];
            }
            else
            {
                child = new Dir(path);
                Dirs.Add(path, child);
            }
            return child;
        }
    }

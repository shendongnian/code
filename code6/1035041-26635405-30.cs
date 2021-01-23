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
        public Dir FindOrCreate(string path, bool mightBeFile = true)
        {
            int i = path.IndexOf('/');
            if (i > -1)
            {
                Dir dir = FindOrCreate(path.Substring(0, i), false);
                return dir.FindOrCreate(path.Substring(i + 1), true);
            }
            if (path == "") return this;
            // if the name is at the end of a path and contains a "." 
            // we assume it is a file (unless it is "." by itself)
            if (mightBeFile && path != "." && path.Contains("."))
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

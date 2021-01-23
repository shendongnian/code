        public IEnumerable<string> GetDirInfoFast(string dir, string pattern)
        {
            //you should put try catch here....
            var di = new DirectoryInfo(dir);
            var list = new List<string>();
            //put in the pattern
            var dirs = di.GetDirectories(pattern);
            Parallel.ForEach(dirs, p => {
                list.Add(p.Name);
            });
            return list;
        }

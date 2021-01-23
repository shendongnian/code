        public static IEnumerable<string> GetFiles(
            string rootDirectory,
            Func<string, bool> directoryFilter,
            string filePattern)
        {
            foreach (string matchedFile in Directory.GetFiles(rootDirectory, filePattern, SearchOption.TopDirectoryOnly))
            {
                yield return matchedFile;
            }
            var matchedDirectories = Directory.GetDirectories(rootDirectory, "*.*", SearchOption.TopDirectoryOnly).Where(directoryFilter);
            foreach (var dir in matchedDirectories)
            {
                foreach (var file in GetFiles(dir, directoryFilter, filePattern))
                {
                    yield return file;
                }
            }
        }

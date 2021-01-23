    class FileNameOrderer
    {
        public FileNameOrderer()
        {
            // Add new prefixes to the following list in the order you want:
            orderedPrefixes = new List<string>
            {
                "CV_",
                "Budget_",
                "ProjectDescription_"
            };
        }
        public int Ordinal(string filename)
        {
            for (int i = 0; i < orderedPrefixes.Count; ++i)
                if (filename.StartsWith(orderedPrefixes[i]))
                    return i;
            return orderedPrefixes.Count;
        }
        private readonly List<string> orderedPrefixes;
    }

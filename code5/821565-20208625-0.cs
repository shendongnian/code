        static IEnumerable<string> EnumerateSubdirs(string path)
        {
            return EnumerableEx.Expand(
                       Directory.EnumerateDirectories(path),
                       subPath => Directory.EnumerateDirectories(subPath));
        }

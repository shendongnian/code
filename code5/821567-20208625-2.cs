        static IEnumerable<string> EnumerateSubdirs(string path)
        {
            var subDirs = EnumerableEx.Expand(
                       Directory.EnumerateDirectories(path),
                       subPath => Directory.EnumerateDirectories(subPath));
            return EnumerableEx.Return(path).Concat(subDirs);
        }

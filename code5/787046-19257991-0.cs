    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Foo
    {
        public void DoSomething()
        {
            var x = GetNewestFilePerDirectory(
                @"D:\foo\bar", "*", SearchOption.AllDirectories
            );
        }
        private IEnumerable<FileInfo> GetNewestFilePerDirectory(string root, string pattern, SearchOption searchoption)
        {
            return new DirectoryInfo(root)
                .EnumerateFiles(pattern, searchoption)
                .GroupBy(g => g.Directory.FullName)
                .Select(s => s.OrderBy(f => f.Name)
                    .First(f => f.CreationTimeUtc == s.Max(m => m.CreationTimeUtc))
                );
        }
    }

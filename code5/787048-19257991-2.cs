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
        /// <summary>
        ///     Scans a directory (and, optionally, subdirectories) and returns an
        ///     enumerable of <see cref="FileInfo"/> for the newest file in each
        ///     directory.
        /// </summary>
        /// <param name="root">
        ///     A string specifying the path to scan.
        /// </param>
        /// <param name="pattern">
        ///     The search string. The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="searchoption">
        ///     One of the enumeration values that specifies whether the search operation should
        ///     include only the current directory or all subdirectories. The default value is
        ///     <see cref="SearchOption.TopDirectoryOnly"/>.
        /// </param>
        /// <returns>
        ///     Returns the newest file, per directory.
        /// </returns>
        /// <remarks>
        ///     For directories containing files of the same createtiondate, the first file when
        ///     sorted alphabetical will be returned.
        /// </remarks>
        private IEnumerable<FileInfo> GetNewestFilePerDirectory(
            string root,
            string pattern = "*",
            SearchOption searchoption = SearchOption.TopDirectoryOnly
        )
        {
            return new DirectoryInfo(root)
                .EnumerateFiles(pattern, searchoption)
                .GroupBy(g => g.Directory.FullName)
                .Select(s => s.OrderBy(f => f.Name)
                    .First(f => f.CreationTimeUtc == s.Max(m => m.CreationTimeUtc))
                );
        }
    }

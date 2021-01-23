    public static class Extensions
    {
        public static IEnumerable<string> DistinctBySubString(this IEnumerable<string> strings)
        {
            var results = new List<string>();
            foreach (var s in strings)
            {
                bool add = true;
                for(int i=results.Count-1; i>=0; i--)
                {
                    if (IsSubDirectoryOf(results[i],s))
                    {
                        results.RemoveAt(i);
                    }
                    else if (IsSubDirectoryOf(s,results[i]))
                    {
                        add = false;
                    }
                }
                if (add)
                    results.Add(s);
            }
            return results;
        }
        private static bool IsSubDirectoryOf(string dir1, string dir2)
        {
            DirectoryInfo di1 = new DirectoryInfo(dir1);
            DirectoryInfo di2 = new DirectoryInfo(dir2);
            bool isParent = false;
            while (di2.Parent != null)
            {
                if (di2.Parent.FullName == di1.FullName)
                {
                    isParent = true;
                    break;
                }
                else di2 = di2.Parent;
            }
            return isParent;
        }
    }

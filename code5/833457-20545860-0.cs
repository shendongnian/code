        private static long maxSize = 5 * 1024 * 1024;
        static void Main(string[] args)
        {
            GetDirectorySize(new DirectoryInfo(@"d:\"));
        }
        static long GetDirectorySize(DirectoryInfo dir)
        {
            long size = 0;
            foreach(DirectoryInfo d in dir.EnumerateDirectories("*",SearchOption.TopDirectoryOnly)) {
                size += GetDirectorySize(d);
            }
            size += dir.EnumerateFiles("*",SearchOption.TopDirectoryOnly).Sum(fi => fi.Length);
            if (size > maxSize)
            {
                Console.WriteLine("Directory: {0} Size: {1}", dir, size);
            }
            return size;
        }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(NumberOfFoldersDown(@"c:\temp\", @"c:\temp\"));                   // 0
            Console.WriteLine(NumberOfFoldersDown(@"c:\temp\", @"c:\temp\zz\"));                // 1
            Console.WriteLine(NumberOfFoldersDown(@"c:\temp2\", @"c:\temp\zz\"));               // -1
            Console.WriteLine(NumberOfFoldersDown(@"c:\temp2\", @"c:\temp2\zz\hui\55\"));       // 3
            Console.WriteLine(NumberOfFoldersDown(@"c:\temp2\zz\", @"c:\temp2\zz\hui\55\"));    // 2
    
            Console.Read();
        }
    
        public static int NumberOfFoldersDown(string parentFolder, string subfolder)
        {
            int depth = 0;
            WalkTree(parentFolder, subfolder, ref depth);
            return depth;
        }
    
        public static void WalkTree(string parentFolder, string subfolder, ref int depth)
        {
            var parent = Directory.GetParent(subfolder);
            if (parent == null)
            {
                // Root directory and no match yet
                depth = -1;
            }
            else if (0 != string.Compare(Path.GetFullPath(parentFolder).TrimEnd('\\'), Path.GetFullPath(parent.FullName).TrimEnd('\\'), true))
            {
                // No match yet, continue recursion
                depth++;
                WalkTree(parentFolder, parent.FullName, ref depth);
            }
        }
    }

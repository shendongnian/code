            static void Main(string[] args)
        {
            List<string> paths = new List<string>()
                {
                    @"C:\Users\dynamic user\Desktop\History\2014-11-03\Spreadsheets\excel.xls"
                    ,@"C:\Users\dynamic user\Desktop\History\record.xls"
                    ,@"C:\Users\dynamic user\Desktop\History\2014-11-23\Spreadsheets\excel.xls"
                    ,@"C:\Users\dynamic user\Desktop\History\2014-11-03\excel.xls"
                };
            Console.WriteLine("The common base path of:");
            paths.ForEach(f => Console.WriteLine(f));
            Console.WriteLine("is");
            Console.WriteLine(FindBasePath(paths));
            Console.ReadLine();
        }
        static string FindBasePath(List<string> paths)
        {
            string basePath = String.Empty;
            foreach (string path in paths)
            {
                string dirName = Path.GetDirectoryName(path);
               
                if (paths.All(f => Path.GetDirectoryName(f).Contains(dirName)))
                    return basePath = dirName;
            }
            return basePath;
        }

    namespace DirectorySearch
    {
        class DirectorySearch
        {
            const string PATH = @"C:\Directory Search";
    
            static void Main(string[] args)
            {
    			Console.WriteLine(PATH);
                DirSearch(PATH);
            }
    
            static void DirSearch(string dir, int depth = 1)
            {
                try
                {
    				string indent = new string('\t', depth);
                    foreach (string f in Directory.GetFiles(dir))
                        Console.WriteLine(indent + f);
                    foreach (string d in Directory.GetDirectories(dir))
                    {
                        Console.WriteLine(indent + d);
                        DirSearch(d, depth++);
                    }
    
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

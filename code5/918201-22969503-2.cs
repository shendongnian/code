    public class DirectoryFiles
    {
        public int Count {get; set;}
        
        public string FullPath {get; set;}
        public List<DirectoryFiles> Subdirectories {get; set; }
    }
    private DirectoryFiles Initialize(string fullPath)
    {
        if (Directory.Exists(fullPath))
        {
            var toReturn = new DirectoryFiles { Subdirectories = new List<DirectoryFiles>() };
            foreach (string directory in Directory.GetDirectories(fullPath))
            {
                toReturn.Subdirectories.Add(this.Initialize(directory));
            }
            toReturn.Count = toReturn.Subdirectories.Sum(x => x.Count) + Directory.GetFiles(fullPath).Count();
            return toReturn;
        }
        else
        {
            throw new DirectoryNotFoundException(String.Format("Directory {0} does not exist", fullPath));
        }
    }

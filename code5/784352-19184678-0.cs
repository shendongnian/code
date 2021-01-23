    public void MainMethod()
    {
        List<Files> f1 = new List<Files>() { new Files() { detailId = 5, fileName = "string 1" }, new Files() { detailId = 5, fileName = "string 2" } };
        List<Files> f2 = new List<Files>() { new Files() { detailId = 5, fileName = "string 2" }, new Files() { detailId = 5, fileName = "string 3" } };
    
        var f3 = f1.Union(f2, new FilesComparer()).ToList();
        foreach (var f in f3)
        {
        Console.WriteLine(f.detailId + " " + f.fileName);
        }
    
    }
    public class Files
    {
        public int detailId;
        public string fileName;
    }
    
    public class FilesComparer : IEqualityComparer<Files>
    {
        public bool Equals(Files x, Files y)
        {
            return x.fileName == y.fileName;
        }
    
        public int GetHashCode(Files obj)
        {
            return obj.fileName.GetHashCode();
        }
    }

    class Program
    {
        private static List<Franchise> allFranchises;
        static void Main(string[] args)
        {
            allFranchises = new List<Franchise>
            {
                new Franchise() { FolderName=@"c:\1", InstallerExeName="1.exe" },
                new Franchise() { FolderName=@"c:\2", InstallerExeName="2.exe" },
                new Franchise() { FolderName=@"c:\3", InstallerExeName="3.exe" },
                new Franchise() { FolderName=@"c:\4", InstallerExeName="4.exe" },
                new Franchise() { FolderName=@"c:\5", InstallerExeName="5.exe" },
            };
            Console.WriteLine(ValidateProperty("FolderName", @"c:\2", allFranchises));
            Console.WriteLine(ValidateProperty("InstallerExeName", "5.exe", allFranchises));
            Console.WriteLine(ValidateProperty("FolderName", @"c:\7", allFranchises));
            Console.WriteLine(ValidateProperty("InstallerExeName", "12.exe", allFranchises));
        }
        public static bool ValidateProperty(string propertyName, object propertyValue, IEnumerable<Franchise> validateAgainst)
        {
            PropertyInfo propertyInfo = typeof(Franchise).GetProperty(propertyName);
            return validateAgainst.Any(f => propertyInfo.GetValue(f) == propertyValue);
        }
    }
    public class Franchise
    {
        public string FolderName { get; set; }
        public string InstallerExeName { get; set; }
    }

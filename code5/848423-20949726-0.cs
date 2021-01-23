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
            bool validate1 = ValidateProperty("FolderName", @"c:\2");
            Console.WriteLine(validate1);
            bool validate2 = ValidateProperty("InstallerExeName", "5.exe");
            Console.WriteLine(validate2);
            bool validate3 = ValidateProperty("FolderName", @"c:\7");
            Console.WriteLine(validate3);
            bool validate4 = ValidateProperty("InstallerExeName", "12.exe");
            Console.WriteLine(validate4);
        }
        public static bool ValidateProperty(string propertyName, object validatingPropertyValue)
        {
            PropertyInfo propertyInfo = typeof(Franchise).GetProperty(propertyName);
            var result = allFranchises.Any(f => propertyInfo.GetValue(f) == validatingPropertyValue);
            return result;
        }
    }
    public class Franchise
    {
        public string FolderName { get; set; }
        public string InstallerExeName { get; set; }
    }

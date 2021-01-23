    public class Folder
    {
        public Folder ParentFolder { get; set; }
        public string Name { get; set; }
        public Folder()
        {
        }
        public string GetFullFolderName(string delimiter = ".")
        {
            var folderName = string.Empty;
            if (ParentFolder != null)
            {
                folderName += ParentFolder.GetFullFolderName(delimiter) + delimiter + Name;
            }
            else
            {
                folderName += Name;
            }
            return folderName;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var f1 = new Folder {Name = "f1"};
            var f2 = new Folder {Name = "f2", ParentFolder = f1};
            var f3 = new Folder {Name = "f3", ParentFolder = f2};
            Console.WriteLine(f3.GetFullFolderName());
        }
    }

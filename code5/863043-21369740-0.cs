    class Program {
        static void Main(string[] args) {
            Console.WriteLine(GetTargetPath(@"D:\boot.lnk"));
            Console.WriteLine(GetTargetPath(@"D:\prestigio_notes.lnk"));
            Console.ReadLine();
        }
        private static string GetTargetPath(string ShortcutPath) {
            string pathOnly = System.IO.Path.GetDirectoryName(ShortcutPath);
            string filenameOnly = System.IO.Path.GetFileName(ShortcutPath);
            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder folder = shell.NameSpace(pathOnly);
            Shell32.FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null) {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }
            return ""; // not found
        }
    }

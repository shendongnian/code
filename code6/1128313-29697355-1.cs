    namespace PatternSearch
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private long GetDirectorySize(string folderPath)
            {
                DirectoryInfo di = new DirectoryInfo(folderPath);
                return di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
            }
    
            private void btnSearch_Click(object sender, EventArgs e)
            {
                List<FileList> oLst = new List<FileList>();
    
                string partialName = "webapi";
    
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"C:\MyFolder");
                FileSystemInfo[] filesAndDirs = hdDirectoryInWhichToSearch.GetFileSystemInfos("*" + partialName + "*");
    
                foreach (FileSystemInfo foundFile in filesAndDirs)
                {
                    string fullName = foundFile.FullName;
                    Console.WriteLine(fullName);
    
                    if (foundFile.GetType() == typeof(FileInfo))
                    {
                        FileInfo fileInfo = (FileInfo)foundFile;
                        oLst.Add(new FileList
                        {
                            Name = fileInfo.Name,
                            Type = "File",
                            location = fileInfo.FullName,
                            Size = Format.ByteSize(fileInfo.Length)
                        });
                    }
    
                    if (foundFile.GetType() == typeof(DirectoryInfo))
                    {
                        Console.WriteLine("... is a directory");
                        DirectoryInfo directoryInfo = (DirectoryInfo)foundFile;
                        FileInfo[] subfileInfos = directoryInfo.GetFiles();
                        oLst.Add(new FileList
                        {
                            Name = directoryInfo.Name,
                            Type = "Folder",
                            location = directoryInfo.FullName,
                            Size = Format.ByteSize(GetDirectorySize(directoryInfo.FullName))
                        });
                    }
                }
                dataGridView1.DataSource = oLst;
            }
        }
    
        public class FileList
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string location { get; set; }
            public string Size { get; set; }
        }
    
        public static class Format
        {
            static string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB" };
    
            public static string ByteSize(long size)
            {
                string SizeText = string.Empty;
                const string formatTemplate = "{0}{1:0.#} {2}";
    
                if (size == 0)
                {
                    return string.Format(formatTemplate, null, 0, "Bytes");
                }
    
                var absSize = Math.Abs((double)size);
                var fpPower = Math.Log(absSize, 1000);
                var intPower = (int)fpPower;
                var iUnit = intPower >= sizeSuffixes.Length
                    ? sizeSuffixes.Length - 1
                    : intPower;
                var normSize = absSize / Math.Pow(1000, iUnit);
    
                switch (sizeSuffixes[iUnit])
                {
                    case "B":
                        SizeText= "Bytes";
                        break;
                    case "KB":
                        SizeText = "Kilo Bytes";
                        break;
                    case "MB":
                        SizeText = "Mega Bytes";
                        break;
                    case "GB":
                        SizeText = "Giga Bytes";
                        break;
                    case "TB":
                        SizeText = "Tera Bytes";
                        break;
                    default:
                        SizeText = "None";
                        break;
                }
    
                return string.Format(
                    formatTemplate,
                    size < 0 ? "-" : null, normSize, SizeText
                    );
            }
        }
    }

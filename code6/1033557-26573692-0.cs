    class FileClass
    {
        public string FileName { get; set; }
        public string filePath { get; set; }
        public bool mp3 { get; set; }
        public bool txt { get; set; }
        public bool jpg { get; set; }
    }
    static void Main()
    {
        var list = new List<FileClass>();
        var dirConfig = new DirectoryInfo(@"New Folder");
        var allFiles = dirConfig.GetFiles("*");
        foreach (var fileInfo in allFiles)
        {
            // for purposes of matching files with different extensions,
            // the "fileName" variable below is the file name minus the extension
            var fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length
                - fileInfo.Extension.Length);
            var fileClass = list.Where(fc => fc.FileName == fileName).FirstOrDefault();
            
            if (fileClass == null)
            {
                // this is the first version of this file name,
                // so create a new FileClass instance and add it to the list
                fileClass = new FileClass({
                    FileName = fileName,
                    filePath = Path.Combine(fileInfo.DirectoryName, fileName),
                    mp3 = (fileInfo.Extension.ToLower() == ".mp3"),
                    txt = (fileInfo.Extension.ToLower() == ".txt"),
                    jpg = (fileInfo.Extension.ToLower() == ".jpg")
                });
                list.Add(fileClass);
            }
            else
            {
                // a different version of this file was already found,
                // so just set the boolean flag for this extension
                switch (fileInfo.Extension.ToLower()) {
                    case ".mp3": fileClass.mp3 = true; break;
                    case ".txt": fileClass.txt = true; break;
                    case ".jpg": fileClass.jpg = true; break;
                }
            }
        }
    }

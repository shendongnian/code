    class File
    {
        public Folder Parent;
        public string Name;
        public static void Create(Folder parent, string name)
        {
            Parent.Children.Add(new File { Parent = parent, Name = name });
        }
    }
    var folder = new Folder("windows");
    File.Create(folder, "notepad.exe");
    File.Create(folder, "regedit.exe");

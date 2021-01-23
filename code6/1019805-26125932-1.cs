    class Folder 
    {
        public List<File> Children = new List<File>();
        public string Name;
        public Folder(string name) { Name = name; }
        public void Add(string name)
        {
            Children.Add(new File { Parent = this, Name = name });
        }
    }
    var folder = new Folder("windows");
    folder.Add("notepad.exe");
    folder.Add("regedit.exe");

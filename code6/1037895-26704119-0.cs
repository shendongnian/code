    public class FileAndPath
    {
        public FileAndPath(string file, string path)
        {
            this.File = file;
            this.Path = path;
        }
        public FileAndPath(string path)
        {
            File = System.IO.Path.GetFileName(path);
            Path = path;
        }
        public string File { get; set; }
        public string Path { get; set; }
        public override string ToString()
        {
            return File == null ? string.Empty : File;
        }
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            var other = (FileAndPath)obj;
            return File == other.File && Path == other.Path;
        }
        public override int GetHashCode()
        {
            int code = 0;
            if (File != null)
                code ^= File.GetHashCode();
            if (Path != null)
                code ^= Path.GetHashCode();
            return code;
        }
    }

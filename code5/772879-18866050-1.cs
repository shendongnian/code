    public class FileData
    {
        public string Filename { get; set; }
        public int Size {get; set; }
        public int ContainerFileOffset { get; set; }
    }
    List<FileData> files = new List<FileData>();
    using(Stream stream = new ...Stream(...))
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(files.Count);
        foreach(FileData fd in files)
        {
            writer.Write(Filename);
            writer.Write(Size);
            writer.Write(ContainerFileOffset);
        }
    }

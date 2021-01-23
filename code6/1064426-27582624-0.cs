    public delegate FileStream OpenFileHandler(string filePath);
    public delegate string ChangeVolumeHandler(FileStream stream, int volume);
    
    class Program
    {
        private static FileStream Open(string filePath)
        {
            return File.Open(filePath, FileMode.OpenOrCreate);
        }
        private static string ChangeVolume(FileStream stream, int volume)
        {
            return "Done! Honest!";
        }
        static void Main(string[] args)
        {
            OpenFileHandler ofh = Program.Open;
            ChangeVolumeHandler cvh = Program.ChangeVolume;
            FileStream stream = ofh("path");
            string xyzzy = cvh(stream, 100);
        }
    }

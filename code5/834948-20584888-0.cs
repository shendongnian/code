    public class MediaFile
    {
        public TimeSpan Duration { get; set; }
        public bool HasAudio { get; set; }
        public bool HasVideo { get; set; }
        public String PathToFile { get; set; }
        public MediaFile(string _pathToFile)
        {
            PathToFile = _pathToFile;
        }
    }

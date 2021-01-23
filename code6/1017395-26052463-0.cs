    [STAThread]
    static void Main(string[] Args)
    {
        var mi = new MediaInfo();
        mi.Open(@"video path here");
        var videoInfo = new VideoInfo(mi);
        var audioInfo = new AudioInfo(mi);
         mi.Close();
    }
    public class VideoInfo 
    {
        public string Codec { get; private set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }
        public double FrameRate { get; private set; }
        public string FrameRateMode { get; private set; }
        public string ScanType { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Bitrate { get; private set; }
        public string AspectRatioMode { get; private set; }
        public double AspectRatio { get; private set; }
        public VideoInfo(MediaInfo mi)
        {
            Codec=mi.Get(StreamKind.Video, 0, "Format");
            Width = int.Parse(mi.Get(StreamKind.Video, 0, "Width"));
            Heigth = int.Parse(mi.Get(StreamKind.Video, 0, "Height"));
            Duration = TimeSpan.FromMilliseconds(int.Parse(mi.Get(StreamKind.Video, 0, "Duration")));
            Bitrate = int.Parse(mi.Get(StreamKind.Video, 0, "BitRate"));
            AspectRatioMode = mi.Get(StreamKind.Video, 0, "AspectRatio/String"); //as formatted string
            AspectRatio =double.Parse(mi.Get(StreamKind.Video, 0, "AspectRatio"));
            FrameRate = double.Parse(mi.Get(StreamKind.Video, 0, "FrameRate"));
            FrameRateMode = mi.Get(StreamKind.Video, 0, "FrameRate_Mode");
            ScanType = mi.Get(StreamKind.Video, 0, "ScanType");
        }
    }
    public class AudioInfo
    {
        public string Codec { get; private set; }
        public string CompressionMode { get; private set; }
        public string ChannelPositions { get; private set; }
        public TimeSpan Duration { get; private set; }
        public int Bitrate { get; private set; }
        public string BitrateMode { get; private set; }
        public int SamplingRate { get; private set; }
        public AudioInfo(MediaInfo mi)
        {
            Codec = mi.Get(StreamKind.Audio, 0, "Format");
            Duration = TimeSpan.FromMilliseconds(int.Parse(mi.Get(StreamKind.Audio, 0, "Duration")));
            Bitrate = int.Parse(mi.Get(StreamKind.Audio, 0, "BitRate"));
            BitrateMode = mi.Get(StreamKind.Audio, 0, "BitRate_Mode");
            CompressionMode = mi.Get(StreamKind.Audio, 0, "Compression_Mode");
            ChannelPositions = mi.Get(StreamKind.Audio, 0, "ChannelPositions");
            SamplingRate = int.Parse(mi.Get(StreamKind.Audio, 0, "SamplingRate"));
        }
    }

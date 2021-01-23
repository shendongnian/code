    public class Lightening
    {
        public Lightening(int start, int end)
        {
            StartLocation = start;
            EndLocation = end;
        }
        public int StartLocation { get; private set; }
        public int EndLocation { get; private set; }
    }
    public class Video
    {
        public Video(string name)
        {
            Name = name;
            Lightenings = new List<Lightening>();
        }
        public string Name { get; private set; }
        public List<Lightening> Lightenings { get; private set; }
    }
    ....
    private List<Video> ExtractInfo(string path)
    {
        var videos = new List<Video>();
        Video currentVideo = null;
        using (var file = new System.IO.StreamReader(path))
        {
            string line;
            Regex regex = new Regex(@"\d+");
            while((line = file.ReadLine()) != null)
            {
                if (line.StartsWith("Video"))
                {
                    currentVideo = new Video(line.Split(':')[1].Trim());
                    videos.Add(currentVideo);
                }
                else if (line.StartsWith("Lightning"))
                {
                    var matches = regex.Matches(line);
                    if (matches.Count == 2 && currentVideo != null)
                    {
                        var l = new Lightening(Int32.Parse(matches[0].Value), Int32.Parse(matches[1].Value));
                        currentVideo.Lightenings.Add(l);
                    }
                }
            }
        }
        return videos;
    }

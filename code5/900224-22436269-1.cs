    class Program
    {        
        static void Main(string[] args)
        {
            string fileName = "abcd2.xml";
            string serializationFile = Path.Combine(@"C:\", fileName);
            List<Movie> tmpList = new List<Movie>();
            tmpList.Add(new Movie() { VideoId = "1", Title = "Hello" });
            tmpList.Add(new Movie() { VideoId = "2", Title = "ABCD" });
            MovieList list = new MovieList("Yes", tmpList);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (var writer = XmlWriter.Create(serializationFile, settings))
            {
                var serializer = new XmlSerializer(typeof(MovieList));
                serializer.Serialize(writer, list);
            }
        }
    }
    public class MovieList
    {
        private string custom;
        private List<Movie> movies;
        public MovieList() { }
        public MovieList(string custom, List<Movie> movies)
        {
            this.movies = movies;
            this.custom = custom;
        }
        [XmlAttribute]
        public string CustomAttribute
        {
            get { return this.custom; }
            set { this.custom = value; }
        }
        public List<Movie> Movies
        {
            get
            {
                return  movies;
            }
            set
            {
                this.movies = value;
            }
        }
    }
    public class Movie
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
    }

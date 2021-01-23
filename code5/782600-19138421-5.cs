    public class Album 
    {
        // Note that we make the setter 'private'
        public string Name { get; private set; }
        public string Artist { get; private set; }
        public int Year { get; private set; }
        public Album(string name, string artist, int year)
        {
            this.Name = name;
            this.Artist = artist;
            this.Year = year;
        }
    }

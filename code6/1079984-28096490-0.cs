    public abstract class EntertainmentBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // other common properties
    }
    public class Movie
    {
        // properties specific to a movie
    }
    public class TVSeries
    {
        // properties specific to a TV Series
    }
    public class Note
    {
        public int NoteId { get; set; }
        public int BaseEntertainmentId { get; set; }
    }

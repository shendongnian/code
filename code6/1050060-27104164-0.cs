    public class Person
    {
        public int Id { get; set; }
        public virtual ICollection<Anime> DirectedAnimes { get; set; }
    }
    
    public class Anime
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public virtual Person Director { get; set; }
    }

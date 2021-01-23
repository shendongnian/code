    public class Song:IEntity
    {
        public Song()
        {
            Id = Guid.NewGuid().ToString();
        }
        public virtual Album Album { get; set; }. //add this line
        public string Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
    }

    public class Photo
    {
        public Photo()
        {
            Tags = new HashSet<Tag>();
        }
        public int PhotoId { get; set; }
        
        public int OwnerId { get; set; }
        public string Path { get; set; }
        public string ImageName { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }   
    }
    public class Tag
    {
        public Tag()
        {
            Photos = new HashSet<Photo>();
        }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }

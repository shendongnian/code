    public class Story
    {
        public Story()
        {
            Comments = new Collection<Comments>();
        }
        public int Id { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

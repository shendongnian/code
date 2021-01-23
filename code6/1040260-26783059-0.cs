    public class Story
    {
       public int Id { get; set; }
       public virtual ICollection<Comment> Comments { get; set; }
       public Story()
       {
           Comments = new List<Comment>();
       }
    }

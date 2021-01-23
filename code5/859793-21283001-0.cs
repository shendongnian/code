    public class Archive
    {
      public string Month { get; set; }
      public string Year { get; set; }
      public int Count { get; set; }
      public ICollection<Post> Posts { get; set; }
    }

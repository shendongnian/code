    public interface IHaveLinks
    {
      [IgnoreDataMember]
      IEnumerable<Link> Links { get; }
    }
    public class Link
    {
      public string Name { get; set; }
      public IReturn Request { get; set; }
      public string Method { get; set; }
    }

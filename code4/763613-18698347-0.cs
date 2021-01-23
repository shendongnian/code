    public class BaseItem
    {
      [Key]
      public int Id { get; set; }
      public List<BaseRevision> Revisions { get; set; }
    }
    public class BaseRevision
    {
      [Key]
      public int Id { get; set; }
      [ForeignKey("Id")]
      public BaseItem Item { get; set; }
    }
    [Table("ContentItems")]
    public class ContentItem : BaseItem
    {
        public string ContentType { get; set; }
    }
    [Table("ContentRevisions")]
    public class ContentRevision : BaseRevision
    {
      public string Text { get; set; }
    }

    public class ContentType
    {
         ///other properties
         public ContentType Parent { get; set; }
         public int? ParentId { get; set; }
         public ICollection<ContentType> Childern { get; set; }
    }

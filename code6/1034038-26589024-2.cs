    public class Content
    {
       public virtual IList<ContentText> Texts { get; set; }
       ...
    public class ContentText
    {
       public virtual Content Content { get; set; }
       public virtual int ContentId { get; set; }
       ...

    public class Box
    {
      public int Id { get; private set; }
      public int ParentId { get; private set; }
      public string Content { get; private set; }
    
      public Box(string content, int id, int parentId)
      {
        this.Id = id;
        this.ParentId = parentId;
        this.Content = content;
      }
    }

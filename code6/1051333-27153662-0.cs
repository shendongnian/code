     public class TodoItem
     {
      public string Id { get; set; }       
      [CreatedAt]
      public DateTimeOffset? CreatedAt { get; set; }
      [UpdatedAt]
      public DateTimeOffset? UpdatedAt { get; set; }
      public string Text { get; set; }
      public bool Complete { get; set; }
    }

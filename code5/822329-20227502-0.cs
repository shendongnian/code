    public class Message
    {
      public int Id { get; set; }
      public int FromId { get; set; }
      public int ToId { get; set; }
      public string Subject { get; set; }
      public string From { get; set; }
      public string To { get; set; }
      public DateTime DateTime { get; set; }
      public string Msg { get; set; }
      public bool IsRead { get; set; }
    }

    public class Dialog {
      public DateTime CreatedOn { get; set; }
    }
    public class Response {
      public DateTime      CreatedOn { get; set; }
      public IList<Dialog> Dialogs   { get; set; }
      public DateTime MaxDateTime {
        get {
          if (Dialogs == null) return CreatedOn;
          var max = Dialogs.Max(o => o.CreatedOn);
          return CreatedOn >= max ? CreatedOn : max;
        }
      }
    }
    public class Request{
      public DateTime        CreatedOn { get; set; }
      public IList<Response> Responses { get; set; }
      public DateTime MaxDateTime {
        get {
          if (Responses == null) return CreatedOn;
          var max = Responses.Max(o => o.MaxDateTime);
          return CreatedOn >= max ? CreatedOn : max;
        }
      }
    }

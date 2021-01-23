    public class WorkerResult
    {
      public static class Consts
      {
        public enum Status
        {
          Okay,
          Wrong,
          SomethingElse
        };
      }
    
      public Consts.Status Status { get; set; }
      public object Data { get; set; }
    }

    public class DailyReport
    {
      public DateTime Date {get; set;}
      public int Requests1 {get; set;}
      public int Requests2 {get; set;}
      public int Total // this can be calculated on the fly
      {
        get {return Requests1 + Requests2; }
      }
    }

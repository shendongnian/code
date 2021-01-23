    public class Activity
    {
       public String Name {get; set;}
       public int Score {get; set;}  // out of 10 points
       public override string ToString()
       {
          return String.Format("{0} ({1})", Name, Score);
       }
    }

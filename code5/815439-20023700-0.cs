    public class Teams
    {
      public Teams(Team home, Team away)
      {
         Home = home;
         Away = away;
      }
      public Team Home { get; private set; }
    
      public Team Away { get; private set; }
    }

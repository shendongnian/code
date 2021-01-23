    public class Movie
    {  
       int ID{ get; set; }
       string MovieName {get; set; }
       List<Actor> Actors {get; set; }
    }
     public class Actor
     {
        int ID{get;set}
        string ActorName{ get; set }
        Movie Movie{ get; set; }
        int MovieID{ get; set; }
     }

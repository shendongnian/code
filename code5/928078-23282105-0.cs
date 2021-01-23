    This is my model being loaded in the view:
    public class Problems
    {
     public int ProblemId { get; set; }
     public string Title { get; set; }
 
     public IEnumerable<MyApp.Models.Category> Categories { get; set; }
     public IEnumerable<MyApp.Models.Type> Types {get; set;}
    }

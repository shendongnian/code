    public class Filter
    {
      public string Name {get;set;}
      public bool IsActive {get;set;}
      public bool IsDisplayed {get;set;}
      public string List<Filter> Filters {get;set}
      // Parent
      public Filter Parent {get;set;}
    }

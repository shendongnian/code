    [When(@"When I visit url")]
    public void WhenIVisitUrl(Table table)
    {
      var url = table.CreateInstance<UrlDTO>();
    }
    
    public class UrlDTO{
      public string base { get;set; }
      public string page { get;set; }
      public string parameter1 { get;set; }
      public string parameter2 { get;set; }
    }

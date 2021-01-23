    public class EvenementorEvent
    {
      public string Title { get;set;}
      public string Description { get;set;}
      ....
      ....
      public IEnumerable<System.Web.Mvc.SelectListItem> ListOfData { get;set;}
      public string SelectedData { get;set;}
    }

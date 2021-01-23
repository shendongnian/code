    public class ListController : ApiController
    {
      [HttpGet]
      public ListDTO Get() 
      {
        return new ListDTO() 
        {
          Items = new List<string>() 
          {
            "Item 1",
            "Item 2",
          },
        };
      }
    }

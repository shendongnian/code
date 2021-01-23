    public class ExampleService : Service
    {
      public ExamplesResponse Get(ExamplesRequest request)
      {
        var page = request.Page;
        var data = // get data;
        return new ExamplesResponse
          {
            Examples = data,
            Links = new []
              {
                new Link { Name = "next", Request = request.AddPage(1), Method = "GET" },
                new Link { Name = "previous", Request = request.AddPage(-1), Method = "GET" },
              }
          }
      }
    }
    [Route("/examples/{Page}")]
    public class ExamplesRequest : IReturn<ExamplesResponse>
    {
      public int Page { get; set; }
      // ...
    }

    [Route("/jtip/cases/agencies", "GET")]
    public class AgencyListRequest : IReturn<List<Agency>>
    {
    }
    public class Agency {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    [Route("/jtip/cases/services", "GET")]
    public class ServiceListRequest : IReturn<List<Service>>
    {
    }
    public class Service {
      public int Id { get; set; }
      public string Name { get; set; }
    }

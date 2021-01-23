    using ServiceStack.ServiceClient;
    using ServiceStack.ServiceInterface;
    using ServiceStack.Text;
    using ServiceStack.Service;
    using ServiceStack.ServiceHost;
    using ServiceStack.WebHost;
    using ServiceStack;
    using ServiceStack.ServiceClient.Web;
    using RestTestRoot;  // This is the name of my DTO assembly.  You will need to insert your own here.
    using ServiceStack.ServiceInterface.ServiceModel;
    
    namespace WebApplicationRoot
    {
    
        class HelloClient
        {
            JsonServiceClient hello_client;
    
            //Request DTO
            public class Hello
            {
                public string Name { get; set; }
            }
    
            //Response DTO
            public class HelloResponse
            {
                public string Result { get; set; }
                public ResponseStatus ResponseStatus { get; set; } //Where Exceptions get auto-serialized
            }
            //Can be called via any endpoint or format, see: http://mono.servicestack.net/ServiceStack.Hello/
            public class HelloService : Service
            {
                public object Any(Hello request)
                {
                    return new HelloResponse { Result = "Hello, " + request.Name };
                }
            }
    
            //REST Resource DTO
            [Route("/todos")]
            [Route("/todos/{Ids}")]
            public class Todos : IReturn<List<Todo>>
            {
                public long[] Ids { get; set; }
                public Todos(params long[] ids)
                {
                    this.Ids = ids;
                }
            }
    
            [Route("/todos", "POST")]
            [Route("/todos/{Id}", "PUT")]
            public class Todo : IReturn<Todo>
            {
                public long Id { get; set; }
                public string Content { get; set; }
                public int Order { get; set; }
                public bool Done { get; set; }
            }
    
    
            public HelloClient(){
            //        ServiceStack gateway = new ServiceStack.ClientGateway(
            //               location.protocol + "//" + location.host + '/ServiceStack.Examples.Host.Web/ServiceStack/');
                hello_client = new JsonServiceClient("http://tradetree2.dnsapi.info:8080/");
                hello_client.Get<HelloResponse>("/hello/MyTestWorld!");
            }
        }
    }

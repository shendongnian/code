    public class MyServices : Service{
       private readonly IDocumentSession session;
       public MyServices(IDocumentSession session){
          this.session = session;
       }
       // now use session to query data from database inside your webservice method call
       public object Any(SomeObjectReq request){
          var data = session.Query<ObjectToQuery>().ToList();
       }

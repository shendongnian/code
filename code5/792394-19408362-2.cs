    routes.MapHttpRoute(
        name: "Default", 
        routeTemplate: "api/{controller}/{customer}");
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public HttpResponseMessage Get([FromUri] Customer customer) {};
    GET api/customers?id=1&name=Some+name

    routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{action}/{priceId}/{cost}/{lastUpdate}",
        defaults: new { controller = "service", action="updateprice", priceId = RouteParameter.Optional, cost = RouteParameter.Optional, lastUpdate = RouteParameter.Optional}
    );
    
    string serviceUrl = string.Format("http://localhost:26769/api/service/updateprice/{0}/{1}/{2}", priceId, cost, DateTime.Now);
        WebRequest request = WebRequest.Create(serviceUrl);
        WebResponse response = request.GetResponse();

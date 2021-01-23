    public class MyRemoteAttribute: System.Web.Mvc.RemoteAttribute
    {
      public string GetUrlPublic()
      {
        return this.GetUrl();
      }
      public RouteValueDictionary GetRouteData()
      {
        return this.RouteData;
      }
    }

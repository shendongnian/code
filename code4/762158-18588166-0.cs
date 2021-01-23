     using System.Web;
     using System.Web.Routing;
     using Microsoft.AspNet.FriendlyUrls;
     namespace Utils.Extensions
     {
          public static class HttpRequestExtensions
          {
              public static string GetFileVirtualPathFromFriendlyUrl(this HttpRequest request) 
              {
                 string ret = string.Empty;
                 ret = request.GetFriendlyUrlFileVirtualPath();
                 if (ret == string.Empty)
                 {
                   foreach (RouteBase r in RouteTable.Routes)
                   {
                       if (r.GetType() == typeof(Route))
                       {
                           Route route = (Route)r;
                           if ("/" + route.Url == request.Path)
                           {
                               if (route.RouteHandler.GetType() == typeof(PageRouteHandler))
                               {
                                   PageRouteHandler handler = (PageRouteHandler)route.RouteHandler;
                                   ret = handler.VirtualPath;
                               }
                               break;
                           }
                       }
                   }
                 }
                 return ret;
              }
         }
     }

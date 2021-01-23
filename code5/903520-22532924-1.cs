    using System.Net.Http;
    using System.ServiceModel.Channels;
    using System.Web;
    using System.Web.Http;
 
    namespace Trikks.Controllers.Api
    {
        public class IpController : ApiController
        {
              public string GetIp()
              {
                    return GetClientIp();
              }
 
              private string GetClientIp(HttpRequestMessage request = null)
              {
                    request = request ?? Request;
 
                    if (request.Properties.ContainsKey("MS_HttpContext"))
                    {
                          return   ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                    }
                    else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                    {
                         RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                         return prop.Address;
                    }
                    else if (HttpContext.Current != null)
                    {
                        return HttpContext.Current.Request.UserHostAddress;
                    }
                    else
                    {
                          return null;
                    }
               }
         }
    }

    using Newtonsoft.Json;
    
    namespace Invoicing.HttpHandlers
    {
        [WebService(Namespace = "yournamespace/http-handlers/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class CustomerHandler : IHttpHandler
        {
            #region IHttpHandler Members
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
    
            public void ProcessRequest(HttpContext context)
            {
              // your data-retrieval logic here
              // write json to context.Response
            }
        }

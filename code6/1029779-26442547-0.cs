    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    
    namespace WebApplication1.Controllers
    {
        public class ValuesController : ApiController
        {
            public async Task<Dictionary<string,string>> Post()
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                var provider = new MultipartMemoryStreamProvider();
                var formData = new Dictionary<string,string>();
                try
                {
                    await Request.Content.ReadAsMultipartAsync(provider);
                    foreach (var item in provider.Contents)
                    {
                        formData.Add(item.Headers.ContentDisposition.Name.Replace("\"",""), await item.ReadAsStringAsync());
                    }
                    
                    return formData;
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }    
      }
    }

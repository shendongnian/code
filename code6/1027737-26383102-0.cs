    using OurProject.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    
    namespace OurProject
    {
        /// <summary>
        /// Summary description for PhotoHandler
        /// </summary>
        public class PhotoHandler : HttpTaskAsyncHandler
        {
            private const double CacheDateEpsilonSeconds = 1;
            public override bool IsReusable
            {
                get
                {
                    return true;
                }
            }
    
            public override async Task ProcessRequestAsync(HttpContext context)
            {
                int photoID;
                if (!Int32.TryParse(context.Request.QueryString["ID"], out photoID))
                {
                    context.Response.StatusCode = 400;
                    return;
                }
    
                var dataContext = new DataContext();
    
                PhotoInfo photoInfo = await dataContext.PhotoInfos.SingleOrDefaultAsync(pi => pi.BusinessCardID == photoID);
    
                if (photoInfo == null)
                {
                    context.Response.StatusCode = 404;
                    return;
                }
    
                DateTime clientLastModified;
                
                if (DateTime.TryParse(context.Request.Headers["If-Modified-Since"], out clientLastModified) &&
                    clientLastModified.AddSeconds(CacheDateEpsilonSeconds) >= photoInfo.LastModifiedDate)
                {
                    context.Response.StatusCode = 304;
                    context.Response.StatusDescription = "Not Modified";
                    return;
                }
    
                context.Response.Cache.SetCacheability(HttpCacheability.Private);
                context.Response.Cache.VaryByParams["d"] = true;
                context.Response.Cache.SetLastModified(photoInfo.LastModifiedDate);
                context.Response.Cache.SetMaxAge(new TimeSpan(365, 0, 0, 0));
                context.Response.Cache.SetOmitVaryStar(true);
                context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(365));
                context.Response.Cache.SetValidUntilExpires(true);
    
                PhotoFile file = await dataContext.PhotoFiles.SingleAsync(pf => pf.BusinessCardID == photoID);
    
                context.Response.ContentType = photoInfo.MimeType;
                context.Response.BinaryWrite(file.PhotoData);
    
            }
        }
    }

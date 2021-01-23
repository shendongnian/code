    using OurProject.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    
    namespace OurProject
    {
        public class PhotoHandler : HttpTaskAsyncHandler
        {
            private const double CacheDateEpsilonSeconds = 1;
            public override bool IsReusable
            {
                get
                {
                    //the handler does not store any state so the object can be reused
                    return true;
                }
            }
    
            public override async Task ProcessRequestAsync(HttpContext context)
            {
                //get the id of the photo object
                int photoID;
                if (!Int32.TryParse(context.Request.QueryString["ID"], out photoID))
                {
                    context.Response.StatusCode = 400;
                    return;
                }
    
                var dataContext = new DataContext();
                //retrieve the object metadata from the database. Not that the call is async so it does not block the thread while waiting for the database to respond
                PhotoInfo photoInfo = await dataContext.PhotoInfos.SingleOrDefaultAsync(pi => pi.BusinessCardID == photoID);
    
                //if the object is not found return the appropriate status code
                if (photoInfo == null)
                {
                    context.Response.StatusCode = 404;
                    return;
                }
    
                DateTime clientLastModified;
                
                //check if the image has been modified since it was last served
                //if not return 304 status code
                if (DateTime.TryParse(context.Request.Headers["If-Modified-Since"], out clientLastModified) &&
                    clientLastModified.AddSeconds(CacheDateEpsilonSeconds) >= photoInfo.LastModifiedDate)
                {
                    context.Response.StatusCode = 304;
                    context.Response.StatusDescription = "Not Modified";
                    return;
                }
    
                //set various cache options
                context.Response.Cache.SetCacheability(HttpCacheability.Private);
                context.Response.Cache.VaryByParams["d"] = true;
                context.Response.Cache.SetLastModified(photoInfo.LastModifiedDate);
                context.Response.Cache.SetMaxAge(new TimeSpan(365, 0, 0, 0));
                context.Response.Cache.SetOmitVaryStar(true);
                context.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(365));
                context.Response.Cache.SetValidUntilExpires(true);
    
                //Get the actual file data. Again note the async IO call
                PhotoFile file = await dataContext.PhotoFiles.SingleAsync(pf => pf.BusinessCardID == photoID);
    
                //serve the image with the appropriate MIME type. In this case the MIME type is determined when saving in the database
                context.Response.ContentType = photoInfo.MimeType;
                context.Response.BinaryWrite(file.PhotoData);
    
            }
        }
    }

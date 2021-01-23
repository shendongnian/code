    public class TestController : ApiController
    {
        private cdw db = new cdw();
    
        public HttpResponseMessage get([FromUri] Query query)
        {
            IQueryable<data_qy> data = null;
            if (!string.IsNullOrEmpty(query.tag))
            {
                var ids = query.tag.Split(',');
                
                var dataMatchingTags = db.data_qy.Where(c => ids.Any(id =>  c.TAGS.Contains(id)));
                if (data == null)
                     data = dataMatchingTags;
                else
                     data  = data.Union(dataMatchingTags);
            }
    
            if (!string.IsNullOrEmpty(query.name))
            {
                var ids = query.name.Split(',');
    
                var dataMatchingName = db.data_qy.Where(c => ids.Any(id =>  c.NAME.Contains(id)));
                if (data == null)
                     data = dataMatchingName;
                else
                     data  = data.Union(dataMatchingName);
            }
            if (data == null) // If no tags or name is being queried, apply filters to the whole set of products
                data = db.data_qy;
            if (query.startDate != null)
            {
                data  = data.Where(c => c.UploadDate >= query.startDate);
            }
            var materializedData = data.ToList();
            if (!materializedData.Any())
            {
                var message = string.Format("No data found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
    
            }
    
            return Request.CreateResponse(HttpStatusCode.OK, materializedData);
        }
    }

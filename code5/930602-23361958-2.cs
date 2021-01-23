    public class TestController : ApiController
    {
        private cdw db = new cdw();
    
        public HttpResponseMessage get([FromUri] Query query)
        {
            var data = db.data_qy.AsQueryable();
    
            if (query.startDate != null)
            {
                data = data.Where(c => c.UploadDate >= query.startDate);
            }
    
            if (!string.IsNullOrEmpty(query.tag))
            {
                var ids = query.tag.Split(',');
    
                data = data.Where(c => ids.Contains(c.TAGS)));
                // or data  = data.Where(c => ids.Any(id => id == c.TAGS));
            }
    
            if (!string.IsNullOrEmpty(query.name))
            {
                var ids = query.name.Split(',');
    
                data = data.Where(c => ids.Contains(c.NAME)));
            }
    
            var materializedData = data.ToList();
            if (!data.Any())
            {
                var message = string.Format("No data found");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
    
            }
    
            return Request.CreateResponse(HttpStatusCode.OK, materializedData);
        }
    }

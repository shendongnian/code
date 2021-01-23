    public class TestController : ApiController
    {
        private cdw db = new cdw();
    
        public HttpResponseMessage get([FromUri] Query query)
        {
            var data = db.data_qy.AsQueryable();
            IQueryable<data_qy> initialFilteredData = data;
            if (!string.IsNullOrEmpty(query.tag))
            {
                var ids = query.tag.Split(',');
    
                data  = data.Union(initialFilteredData.Where(c => ids.Any(id =>  c.TAGS.Contains(id))));
            }
    
            if (!string.IsNullOrEmpty(query.name))
            {
                var ids = query.name.Split(',');
    
                data  = data.Union(initialFilteredData.Where(c => ids.Any(id =>  c.TAGS.Contains(id))));
            }
    
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

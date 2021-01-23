    public class PlanController : ApiController
    {
        public ThingVM Get()
        {
            using (var context = new MyContext())
            {
                var model = new ThingVM();
                return model;
            }
        }
    
        public HttpResponseMessage Post(ThingVM model)
        {
            HttpResponseMessage response;
    
            if (ModelState.IsValid)
            {
                using (var context = new MyContext())
                {
    
                    var thing = new Thing();
    
                    context.Thing.Add(thing);
                    context.SaveChanges();
                    response = Request.CreateResponse(HttpStatusCode.Created);
                    string uri = Url.Link("GetThingById", new {id = thing.Id});
                    response.Headers.Location = new Uri(uri);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }
    }

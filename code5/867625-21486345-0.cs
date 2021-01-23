        public class UserController : ApiController
        {
            [Authorize]
            public HttpResponseMessage Get([FromUri] Query query)
            {
                BusinessLayer layer = new BusinessLayer();
                if (User.IsInRole("user"))
                {
                    var result = layer.GetData(query);
                    // use result here and return HttpResponseMessage
                    var message = string.Format("No data was found");
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
        }

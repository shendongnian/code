        public class EventsFilter : ActionFilterAttribute
        {
            public EventDBContext EventDBContext { get; set; }
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                bool exists = false;
                var routeData = actionContext.Request.GetRouteData();
                object value;
                if (routeData.Values.TryGetValue("id", out value))
                {
                    int id;
                    if (int.TryParse(value, out id))
                    {
                        exists = EventDBContext.EventRosters.Where(x => x.eventID == id).Any();
                    }
                }
                if (exists == false)
                {
                    var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event not found");
                    throw new HttpResponseException(response);       
                }
            }
        }

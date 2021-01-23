    public class ValuesController : ApiController
    {
        [Route("api/values/MyName", Order = 1)]
        [Route("api/values/{name}", Order = 2)]
        public string Get()
        {
            object nameObj;
            Request.GetRouteData().Values.TryGetValue("name", out nameObj);
    
            if (nameObj != null)
            {
                // came from second route
                return "Route is {name} and name was: " + (string) nameObj;
            }
            else
            {
                return "Route is MyName so no name value is available";
            }
        }
    }

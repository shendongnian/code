    [Route("/t/{verb}/{path*}","GET")]
    public class MapVerbRequest 
    {
        public string Verb { get; set; }
        public string Path { get; set; }
    }
    public class MapVerbController : Service
    {
        public object Get(MapVerbRequest request)
        {
            if(!Request.IsLocal)
                throw HttpError.Unauthorized("You can't do that!");
            // Determine the real path
            var raw = Request.AbsoluteUri.Replace(string.Format("/t/{0}",request.Verb), "");
            // Create a client
            var client = new JsonServiceClient();
            // Run the request with the desired verb
            return client.Send<object>(request.Verb, raw, "");
        }
    }

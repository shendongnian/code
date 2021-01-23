    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = parameters => {
                return new Response {
                    StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Hello World"
                };
            };
        }
    }

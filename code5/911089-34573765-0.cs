     public class ServiceNotFoundException : HttpResponseException
        {
            public ServiceNotFoundException() : base(HttpStatusCode.NotFound)
            {
               
            }
        }

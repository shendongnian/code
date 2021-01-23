    public class GeoPoint
    {
        public double? Latitude { get; set; } 
        public double? Longitude { get; set; }
    }
    
        public ValuesController : ApiController
        {
            public HttpResponseMessage Get([FromUri] GeoPoint location) 
            { 
                 if(location == null || location.Longitude == null || location.Latitude == null)
                    throw new Exception("404'd");
            }
        }

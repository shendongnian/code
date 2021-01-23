    public class GeoPoint
    {
        private double? _latitude;
        private double? _longitude;
        
        public double Latitude {
            get { return _latitude ?? 0; }
            set { _latitude = value; }
        }
        
        public double Longitude { 
            get { return _longitude ?? 0; }
            set { _longitude = value; }
        }
        
        public bool IsValid()
        {
            return ( _latitude != null && _longitude != null )
    }
    
    public ValuesController : ApiController
    {
        public HttpResponseMessage Get([FromUri] GeoPoint location)
        {
            if ( !location.IsValid() ) { throw ... }
            ...
        }
    }

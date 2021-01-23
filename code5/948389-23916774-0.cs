    private string SerializeObject<T>(this T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
        StringWriter textWriter = new StringWriter();
    
        xmlSerializer.Serialize(textWriter, toSerialize);
        return textWriter.ToString();
    }
    public class KmlController : ApiController
    {
        public string Get()
        {
            Point point = new Point();
            point.Coordinate = new Vector(37.42052549, -122.0816695);
    
            Placemark placemark = new Placemark();
            placemark.Name = "Somewhere";
            placemark.Geometry = point;
    
            Kml kml = new Kml();
            kml.Feature = placemark;
            
            return SerializeObject<Kml>(kml);;
        }
    }

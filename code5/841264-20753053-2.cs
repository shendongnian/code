    [XmlRoot("current")]
    public class WeatherReading
    {
      
      [XmlElement("city")]
      public WeatherReadingCity City { get ; set ; }
      
      [XmlElement("temperature")]
      public WeatherReadingTemperature Temperature { get ; set ; }
      
    }
    
    public class WeatherReadingTemperature
    {
      
      [XmlAttribute("value")]
      public double Current { get ; set ; }
      
      [XmlAttribute("min")]
      public double Minimum { get ; set ; }
      
      [XmlAttribute("max")]
      public double Maximum { get ; set ; }
      
      [XmlAttribute("unit")]
      public TemperatureScale Scale { get ; set ; }
      
    }
    
    public enum TemperatureScale
    {
      Unknown     = 0 ,
      Fahrenheith = 1 ,
      Centigrade  = 2 ,
      Celsius     = 2 ,
      Kelvin      = 3 ,
    }
    
    public class WeatherReadingCity
    {
      
      [XmlAttribute("id")]
      public int Id { get ; set ; }
      
      [XmlAttribute("name")]
      public string Name { get ; set ; }
      
      [XmlElement("coord")]
      public WeatherReadingPosition Position { get ; set ; }
      
    }
    
    public class WeatherReadingPosition
    {
      
      [XmlAttribute("lat")]
      public double Latitude  { get ; set ; }
      
      [XmlAttribute("long")]
      public double Longitude { get ; set ; }
      
    }
    

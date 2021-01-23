    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WindDeserialize
    {
        using System.IO;
        using System.Xml.Serialization;
        
        class Program
        {
            public const string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?>                                "+  
    "<CurrentWeather>                                                                               "+
    "  <Location>BOSTON LOGAN INTERNATIONAL, MA, United States (KBOS) 42-22N 071-01W 54M</Location> "+
    "  <Time>Feb 11, 2015 - 11:54 AM EST / 2015.02.11 1654 UTC</Time>                               "+
    "  <Wind> from the N (010 degrees) at 17 MPH (15 KT) gusting to 26 MPH (23 KT):0</Wind>         "+
    "  <Visibility> 2 mile(s):0</Visibility>                                                        "+
    "  <SkyConditions> overcast</SkyConditions>                                                     "+
    "  <Temperature> 19.9 F (-6.7 C)</Temperature>                                                  "+
    "  <Wind>Windchill: 5 F (-15 C):1</Wind>                                                        "+
    "  <DewPoint> 12.9 F (-10.6 C)</DewPoint>                                                       "+
    "  <RelativeHumidity> 73%</RelativeHumidity>                                                    "+
    "  <Pressure> 30.08 in. Hg (1018 hPa)</Pressure>                                                "+
    "  <Status>Success</Status>                                                                     "+
    "</CurrentWeather>                                                                              ";
            static void Main(string[] args)
            {
                XmlSerializer ser = new XmlSerializer(typeof(CurrentWeather));
    
                var weather = (CurrentWeather)ser.Deserialize(new StringReader(xml));
    
            }
    
    
        }
    
        public class CurrentWeather
        {
            [XmlElement]
            public string Location { get; set; }
            [XmlElement]
            public string Time { get; set; }
            [XmlElement]
            public string [] Wind { get; set; }
            [XmlElement]
            public string Visibility { get; set; }
            [XmlElement]
            public string SkyConditions { get; set; }
            [XmlElement]
            public string Temperature { get; set; }
            [XmlElement]
            public string DewPoint { get; set; }
            [XmlElement]
            public string RelativeHumidity { get; set; }
            [XmlElement]
            public string Pressure { get; set; }
            [XmlElement]
            public string Status { get; set; }
        }
    }
